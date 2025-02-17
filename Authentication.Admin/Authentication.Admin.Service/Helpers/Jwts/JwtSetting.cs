using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Helpers.Jwts
{
    public class JwtSetting
    {
        public string Aud { get; set; }
        public int ExpireMinutes { get; set; }
        public int ExpireHours { get; set; }
        public int ExpireSeconds { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
    }
}
