using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Entities
{
    public class AuthenticationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationUserDbContext(DbContextOptions<AuthenticationUserDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
    }
}
