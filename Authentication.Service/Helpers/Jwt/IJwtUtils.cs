using Authentication.Service.ViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public JwtToken GenerateToken(UserViewModel user);
        public int? ValidateToken(string token);
    }
}
