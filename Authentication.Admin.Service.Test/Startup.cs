using Authentication.Admin.Service.DependencyInjections;
using Authentication.Admin.Service.Helpers.Jwts;
using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.Services.UserServices.Services;
using Authentication.Admin.Service.ViewModels.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Authentication.Admin.Service.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();


            services.AddHttpContextAccessor();
            services.AddAuthorization();
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
            services.AddServiceLayer(configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Aud"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"] ?? ""))
                };
            });
        }
       
    }
}
