using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Helpers.Jwts
{
    public class JwtToken
    {
        public string Token { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
