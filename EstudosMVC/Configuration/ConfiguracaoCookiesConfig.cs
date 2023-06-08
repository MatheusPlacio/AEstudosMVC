namespace AEstudosMVC.Configuration
{
    public static class ConfiguracaoCookiesConfig
    {
        public static void ConfigurarCookies(this IServiceCollection service)
        {
            service.ConfigureApplicationCookie(x =>
            {
                x.Cookie.Name = "IdentityCookie";
                x.Cookie.HttpOnly = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                x.LoginPath = "/Usuarios/Login";
            });
        }
    }
}
