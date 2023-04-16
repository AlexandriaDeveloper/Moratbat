using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            this._config = config;
        }
        public  string CreateToken(AppUser user,IList<string>? userRoles){
            List<Claim> claims = new List<Claim>{
                
                new Claim(ClaimTypes.Name,user.DisplayName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName!),
           
            };
               if(userRoles!.Any()){
                foreach (var role in userRoles!)
                {
                    claims.Add(new Claim(ClaimTypes.Role,role));
                }
              }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["TokenKey"]));
            var creds = new SigningCredentials (key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptot = new SecurityTokenDescriptor{
                Subject= new ClaimsIdentity(claims),
                Expires =DateTime.Now.AddDays(7),
                SigningCredentials=creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptot);
            return tokenHandler.WriteToken(token);

        }
    }
}