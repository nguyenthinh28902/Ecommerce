using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Constructors
{
    public class DataModel
    {
        public static UserToken CreateUserToken(string JwtToken, string LoginProvider, string AppName, DateTimeOffset ExpiresAt, 
            string IdentytiUserId, TokenType TokenType, string IpClient)
        {
            var userToken = new UserToken();
            userToken.IdentityUserId = IdentytiUserId;
            userToken.Token = JwtToken;
            userToken.LoginProvider = LoginProvider;
            userToken.AppName = AppName;
            userToken.ExpiresAt = ExpiresAt;
            userToken.CreatedAt = DateTimeOffset.UtcNow;
            userToken.TokenType = TokenType;
            userToken.IpClient = IpClient;
           
            return userToken;
        }
    }
}
