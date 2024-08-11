using Authentication.DataAccess.Service.User.Interface;
using Authentication.DataAccess.Service.User.Service;
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
            services.AddSingleton<IUserManagerService, UserManagerService>();
            return services;
        }
    }
}
