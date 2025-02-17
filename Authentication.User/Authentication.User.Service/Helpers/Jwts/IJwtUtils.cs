using Authentication.User.Service.ViewModels.UserViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Helpers.Jwts
{
    public interface IJwtUtils
    {
        public JwtToken GenerateToken(UserViewModel user);
        public int? ValidateToken(string token);
    }
}
