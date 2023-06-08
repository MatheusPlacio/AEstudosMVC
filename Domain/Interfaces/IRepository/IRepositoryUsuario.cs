using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces.IRepository
{
    public interface IRepositoryUsuario : IRepositoryGenerico<Usuario>
    {
        int VerificarSeExisteRegistro();
        Task LogarUsuario(Usuario usuario, bool lembrar);
        Task DeslogarUsuario();
        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);
        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);
        Task<Usuario> PegarUsuarioPeloEmail(string email);

    }
}
