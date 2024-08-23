
using Authentication.User.DataAccess.Repositories;
using Authentication.User.DataAccess.Service.UserServices.Interfaces;
using Authentication.User.DataAccess.Service.UserServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service
{
    public static class RegisterDataAccessService
    {
        public static IServiceCollection AddRegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessAuthenticationCustomerService(configuration);

            services.AddScoped<IDALAuthenManagerService, DALAuthenManagerService>();
            services.AddScoped<IDALUserManagerService, DALUserManagerService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDALUserTokenMannagerService, DALUserTokenMannagerService>();
            return services;
        }
    }
}
