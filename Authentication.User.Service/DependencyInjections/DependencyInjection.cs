using Authentication.User.Service.Helpers.Jwts;
using Authentication.User.Service.MapperProfiles;
using Authentication.User.Service.Services.EmailService;
using FeatureLibrary.EmailLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.User.Service;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.Services.UserServices.Services;
using Authentication.User.DataAccess.Service;
using Authentication.User.Service.Services.GoogleServices.Interfaces;
using Authentication.User.Service.Services.GoogleServices.Services;
using Authentication.User.Service.Services.ApplicationLogService.Interfaces;
using Authentication.User.Service.Services.ApplicationLogService.Services;
using Authentication.User.Service.Services.StoreServices.Interfaces;
using Authentication.User.Service.Services.StoreServices.Services;
using Authentication.User.Service.Services.StoreServices.Interfaces.AdminService;
using Authentication.User.Service.Services.StoreServices.Services.AdminService;
namespace Authentication.User.Service.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRegisterDataAccessService(configuration);
            services.AddAutoMapper(typeof(MappingUser));
            services.AddAutoMapper(typeof(MappingStore));

            services.AddScoped<EmailLibrary>();
            services.AddTransient<IEmailService, SendMailService>();

            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAuthenManagerService, AuthenManagerService>();
            services.AddHttpClient<IGoogleTokenService, GoogleTokenService>();

            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IUserManagerService, UserManagerService>();

            services.AddScoped<IApplicationLogManagerService, ApplicationLogManagerService>();
            services.AddScoped<IStoreManagerAdminServices, StoreManagerAdminServices>();
            services.AddScoped<IStoreManagerServices, StoreManagerServices>();

            return services;
        }
    }
}
