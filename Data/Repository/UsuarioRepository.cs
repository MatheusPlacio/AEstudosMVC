using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Repository
{
    public class UsuarioRepository : RepositoryGenerico<Usuario>, IRepositoryUsuario
    {
        private readonly MyContext _context;
        private readonly UserManager<Usuario> _gerenciadorUsuarios;
        private readonly SignInManager<Usuario> _gerenciadorLogin;
        public UsuarioRepository(MyContext context, UserManager<Usuario> gerenciadorUsuarios, SignInManager<Usuario> gerenciadorLogin) : base(context)
        {
            _context = context;
            _gerenciadorUsuarios = gerenciadorUsuarios;
            _gerenciadorLogin = gerenciadorLogin;
        }
        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuarios.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuarios.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeslogarUsuario()
        {
            try
            {
                await _gerenciadorLogin.SignOutAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int VerificarSeExisteRegistro()
        {
            try
            {
               var resultado = _context.Usuarios.Count();
               return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Usuario> PegarUsuarioPeloEmail(string email)
        {
            try
            {
               var resultado = await _gerenciadorUsuarios.FindByEmailAsync(email);
                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
