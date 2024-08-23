

using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Admin.DataAccess
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddDataAccessAuthenticationCustomerService(this IServiceCollection services, IConfiguration configuration)
        {
            var AuthenticationAdminService = configuration.GetConnectionString("AuthenticationAdminService");
            // Đăng ký DbContext
            services.AddDbContext<AuthenticationUserDbContext>(options =>
                options.UseSqlServer(AuthenticationAdminService));

            //services.Configure<IdentityOptions>(options => {
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
            //    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
            //    options.Lockout.AllowedForNewUsers = true;
            //    options.SignIn.RequireConfirmedEmail = true; // cần 1 trong 2
            //    options.SignIn.RequireConfirmedPhoneNumber = true;
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationUserDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }

}