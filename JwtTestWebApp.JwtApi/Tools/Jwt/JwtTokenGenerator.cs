using JwtTestWebApp.JwtApi.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTestWebApp.JwtApi.Tools.Jwt
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            if(user.RoleId==1)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            else
                claims.Add(new Claim(ClaimTypes.Role, "Member"));

            JwtSecurityToken token = new JwtSecurityToken
                (issuer:JwtTokenSettings.Issuer,
                audience:JwtTokenSettings.Audience,
                claims:claims,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddDays(JwtTokenSettings.Expire),
                signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtTokenResponse(handler.WriteToken(token));
        }
    }
}
