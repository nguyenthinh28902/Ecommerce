using Authentication.Admin.Service.Helpers.Jwts;
using Authentication.Admin.Service.MapperProfiles;
using Authentication.Admin.Service.Services.EmailService;
using FeatureLibrary.EmailLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Admin.DataAccess.Service;
using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.Services.UserServices.Services;

namespace Authentication.Admin.Service.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRegisterDataAccessService(configuration);
            services.AddAutoMapper(typeof(MappingUser));
            services.AddScoped<EmailLibrary>();
            services.AddTransient<IEmailService, SendMailService>();

            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAuthenManagerService, AuthenManagerService>();

            return services;
        }
    }
}
