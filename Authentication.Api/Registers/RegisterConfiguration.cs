using Authentication.User.Service.Helpers.Jwts;
using Authentication.User.Service.ViewModels.Settings;

namespace Authentication.User.Api.Registers
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
