using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.GoogleServices.DataModels
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        // Add other properties as needed (e.g., refresh_token, expires_in)
    }

}
