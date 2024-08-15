using Authentication.DataAccess.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
