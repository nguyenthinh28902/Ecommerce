using Authentication.User.Service.Services.GoogleServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.GoogleServices.Interfaces
{
    public interface IGoogleTokenService
    {
        public  Task<GoogleProfile> GetUserInfoAsync(string accessToken);
        public  Task<TokenResponse> ExchangeCodeForTokenAsync(string code);
    }
}
