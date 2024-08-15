using Authentication.DataAccess.DataDefault;
using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddDataAccessAuthenticationCustomerService(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationUserService = configuration.GetConnectionString("AuthenticationUserService");
            // Đăng ký DbContext
            services.AddDbContext<AuthenticationUserDbContext>(options =>
                options.UseSqlServer(
                    authenticationUserService, // Chuỗi kết nối của bạn
                    b => b.MigrationsAssembly(typeof(AuthenticationUserDbContext).Assembly.FullName)));

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lần thì khóa
                options.Lockout.AllowedForNewUsers = true;
                options.SignIn.RequireConfirmedEmail = true; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationUserDbContext>().AddDefaultTokenProviders();         
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }

}
