using Authentication.DataAccess;
using Authentication.DataAccess.Service;
using Authentication.Service.Helpers.Jwt;
using Authentication.Service.MapperProfile;
using Authentication.Service.Services.EmailService;
using Authentication.Service.Services.UserService.Interface;
using Authentication.Service.Services.UserService.Service;
using Authentication.Service.ViewModel;
using FeatureLibrary.EmailLibrary;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRegisterDataAccessService(configuration);
            services.AddAutoMapper(typeof(MappingUser));
            services.AddScoped<EmailLibrary>();
            services.AddTransient<IEmailSender, SendMailService>();
            
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAuthenManagerService, AuthenManagerService>();
            
            return services;
        }
    }
}
