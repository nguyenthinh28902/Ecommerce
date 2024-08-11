using Authentication.Service.ViewModel.Settings;

namespace Authentication.Admin.Api.Register
{
    public static class RegisterConfiguration
    {
        public static IServiceCollection AddRegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            return services;
        }
    }
}
