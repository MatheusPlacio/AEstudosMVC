using AEstudosMVC.DTOs;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AEstudosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsuariosController(IRepositoryUsuario repositoryUsuario, IWebHostEnvironment webHostEnvironment)
        {
            _repositoryUsuario = repositoryUsuario;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroDTO model, IFormFile foto)
        {
            if (ModelState.IsValid) 
            {
                if (foto != null)
                {
                    string diretorioPasta = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");
                    string nomeFoto = Guid.NewGuid().ToString() + foto.FileName;

                    using (FileStream fileStream = new FileStream(Path.Combine(diretorioPasta, nomeFoto), FileMode.Create)) 
                    {
                        await foto.CopyToAsync(fileStream);
                        //model.Foto = "~/Imagens/" + nomeFoto;
                    }
                }

                Usuario usuario = new Usuario();
                IdentityResult usuarioCriado;

                if (_repositoryUsuario.VerificarSeExisteRegistro() == 0)
                {
                    usuario.UserName = model.Nome;
                    usuario.CPF = model.CPF;
                    usuario.Email = model.Email;
                    usuario.PhoneNumber = model.Telefone;
                    usuario.Foto = model.Foto.ToString();
                    usuario.PrimeiroAcesso = false;
                    usuario.Status = StatusConta.Aprovado;

                    usuarioCriado = await _repositoryUsuario.CriarUsuario(usuario, model.Senha);

                    if(usuarioCriado.Succeeded)
                    {
                        await _repositoryUsuario.IncluirUsuarioEmFuncao(usuario, "Administrador");
                        await _repositoryUsuario.LogarUsuario(usuario, false);
                        return RedirectToAction("Index", "Usuarios");
                    }
                }

                usuario.UserName = model.Nome;
                usuario.CPF = model.CPF;
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.Telefone;
                usuario.Foto = model.Foto.ToString();
                usuario.PrimeiroAcesso = true;
                usuario.Status = StatusConta.Analisando;

                usuarioCriado = await _repositoryUsuario.CriarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    return View("Analise", usuario.UserName);
                }

                else
                {
                    foreach (IdentityError erro in usuarioCriado.Errors)
                    {
                        ModelState.AddModelError("", erro.Description);
                    }

                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _repositoryUsuario.DeslogarUsuario();
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _repositoryUsuario.PegarUsuarioPeloEmail(model.Email);

                if(usuario != null)
                {
                    if (usuario.Status == StatusConta.Analisando)
                    {
                        return View("Analise", usuario.UserName);
                    }

                    else if(usuario.Status == StatusConta.Reprovado)
                    {
                        return View("Reprovado", usuario.UserName);
                    }

                    else if(usuario.PrimeiroAcesso == true)
                    {
                        return View("RedefinirSenha", usuario);
                    }

                    else
                    {
                        PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();

                        if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != PasswordVerificationResult.Failed)
                        {
                            await _repositoryUsuario.LogarUsuario(usuario, false);
                            return RedirectToAction("Index");
                        }

                        else
                        {
                            ModelState.AddModelError("", "Email e/ou senhas inválidas");
                            return View(model);
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Email e/ou senhas inválidas");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _repositoryUsuario.DeslogarUsuario();
            return RedirectToAction("Login");
        }

        public IActionResult Analise(string nome)
        {
            return View(nome);
        }
    }
}
