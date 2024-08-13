using Authentication.Service.Helpers.Jwt;
using Authentication.Service.ViewModel.Settings;

namespace Authentication.Admin.Api.Register
{
    public static class RegisterConfiguration
    {
        public static IServiceCollection AddRegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
            return services;
        }
    }
}
