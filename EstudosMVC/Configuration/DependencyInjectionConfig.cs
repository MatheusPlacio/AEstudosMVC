using Data.Repository;
using Domain.Interfaces.IRepository;

namespace AEstudosMVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUsuario, UsuarioRepository>();
        }
    }
}
