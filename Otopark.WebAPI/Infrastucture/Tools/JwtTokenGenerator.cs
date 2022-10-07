using Microsoft.IdentityModel.Tokens;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Otopark.WebAPI.Infrastucture.Tools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto checkUserResponseDto)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);



            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));
            claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, checkUserResponseDto.Id.ToString()));

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenSettings.Issuer,audience:JwtTokenSettings.Audience,claims:claims,notBefore:DateTime.UtcNow,expires: DateTime.UtcNow.AddDays(JwtTokenSettings.Expire),signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtTokenResponse(handler.WriteToken(token));
        }
    }
}
