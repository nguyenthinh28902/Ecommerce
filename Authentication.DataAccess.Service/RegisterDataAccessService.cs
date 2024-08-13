using Authentication.DataAccess.Repositories;
using Authentication.DataAccess.Service.User.Interface;
using Authentication.DataAccess.Service.User.Service;
using Authentication.DataAccess.Service.UserService.Interface;
using Authentication.DataAccess.Service.UserService.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service
{
    public static class RegisterDataAccessService
    {
        public static IServiceCollection AddRegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessAuthenticationCustomerService(configuration);
           
            services.AddScoped<IDALAuthenManagerService, DALAuthenManagerService>();
            services.AddScoped<IDALUserManagerService, DALUserManagerService>();
            services.AddScoped<IDALUserTokenMannagerService, DALUserTokenMannagerService>();
            return services;
        }
    }
}
