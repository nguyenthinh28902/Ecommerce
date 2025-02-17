using Authentication.User.Service.ViewModels.UserViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Helpers.Jwts
{
    public class JwtUtils : IJwtUtils
    {
        private readonly JwtSetting _appSettings;

        public JwtUtils(IOptions<JwtSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public JwtToken GenerateToken(UserViewModel user)
        {
            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            Claims.Add(new Claim(JwtRegisteredClaimNames.Aud, _appSettings.Aud));
            var ExpiryDuration = new TimeSpan(_appSettings.ExpireHours, _appSettings.ExpireMinutes, _appSettings.ExpireSeconds);
            var expiresAt = DateTime.Now.Add(ExpiryDuration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer, Claims,
                expires: expiresAt, signingCredentials: credentials);
            var jwtToken = new JwtToken();
            jwtToken.Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            jwtToken.ExpiresAt = expiresAt;
            return jwtToken;
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
