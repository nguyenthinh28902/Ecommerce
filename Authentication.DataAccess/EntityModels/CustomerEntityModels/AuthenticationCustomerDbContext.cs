using Authentication.DataAccess.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.EntityModels
{
    public class AuthenticationCustomerDbContext : IdentityDbContext<ApplicationCustomer>
    {
        public AuthenticationCustomerDbContext(DbContextOptions<AuthenticationCustomerDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
    }
}
