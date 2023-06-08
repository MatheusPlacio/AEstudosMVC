using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace AEstudosMVC.Configuration
{
    public static class ConfiguracaoIdentityConfig
    {
        public static void ConfigurarNomeUsuario(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<MyContext>();
            services.Configure<IdentityOptions>(x =>
            {
                x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                x.User.RequireUniqueEmail = true;
            });
        }

        public static void ConfigurarSenhaUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireDigit = true;
                x.Password.RequireLowercase = true;
                x.Password.RequiredLength = 8;
                x.Password.RequireNonAlphanumeric = true;
                x.Password.RequireUppercase = true;
                x.Password.RequiredUniqueChars = 0;
            });
        }
    }
}
