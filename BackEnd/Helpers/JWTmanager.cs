using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BackEnd.DTO;
using BackEnd.Helpers;
using FullStack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BackEnd.Helpers.Interfaces;

namespace BackEnd.Helpers
{
    public class JWTmanager : IJWTmanager
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        public JWTmanager(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _accessor = accessor;

        }
        public string GenerateJwtToken(User user, int hours = 0)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = (hours == 0) ? DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"])) : DateTime.Now.AddHours(hours);

            var token = new JwtSecurityToken(
                null, null,
                claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserClaims AuthorizationKeyDecoder(string jwtEncodedString)
        {
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            var userId = token.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var fullName = token.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            var email = token.Claims.First(x => x.Type == ClaimTypes.Email).Value;

            return new UserClaims
            {
                id = Convert.ToInt32(userId),
                name = fullName,
                email = email
            };
        }

        public string GetIP()
        {
            return _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        }

        public UserClaims GetUserClaims()
        {
            string authHeader = _accessor.HttpContext?.Request?.Headers["Authorization"];

            return GetDecodedClaims(authHeader);
        }

        public UserClaims GetUserClaims(HttpContext httpContext)
        {
            string authHeader = httpContext?.Request?.Headers["Authorization"];

            return GetDecodedClaims(authHeader);
        }

        private UserClaims GetDecodedClaims(string authHeader)
        {
            if (authHeader != null)
            {
                var jwtEncodedString = authHeader.Substring(7);
                return AuthorizationKeyDecoder(jwtEncodedString);
            }
            else
                return null;
        }
    }
}