using Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponse GenerateToken(CheckAppUserQueryResult checkAppUser)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(checkAppUser.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, checkAppUser.Role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, checkAppUser.AppUserID.ToString()));
            if (!string.IsNullOrWhiteSpace(checkAppUser.Username))
            {
                claims.Add(new Claim("Username", checkAppUser.Username));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = DateTime.Now.AddMinutes(JwtTokenDefaults.ExpireMinutes);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.Now, expires: expire, signingCredentials: credentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponse(tokenHandler.WriteToken(token), expire);
        }
    }
}
