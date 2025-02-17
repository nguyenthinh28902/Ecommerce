using Authentication.Admin.Service.Helpers.Jwts;
using Authentication.Admin.Service.ViewModels.Settings;

namespace Authentication.Admin.Api.Registers
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
