using Callisto.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Services
{
    public class TokenService
    {
        public static string Generate(User user)
        {
            //Cria a instância do JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };

            //Gera um token
            var token = handler.CreateToken(tokenDescriptor);

            //Gera uma string do Token
            return handler.WriteToken(token);
        }
        public static ClaimsIdentity GenerateClaims(User user) 
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(
                new Claim(ClaimTypes.Name, user.Name.ToString()));
            ci.AddClaim(
                new Claim(ClaimTypes.Role, user.Role.ToString()));
             ci.AddClaim(
                new Claim("userId", user.Id.ToString()));

            return ci;
        }
    }
}
