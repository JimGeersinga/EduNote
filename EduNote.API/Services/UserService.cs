using EduNote.API.EF.Helpers;
using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EduNote.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _dataService;
        private readonly AppSettings _appSettings;

        public UserService(IRepository dataService, IOptions<AppSettings> appSettings)
        {
            _dataService = dataService;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string email, string password)
        {
            User user = _dataService.GetFirst<User>(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            if (!Encryption.Verify(password, user.Password))
            {
                return null;
            }

            user.Token = GenerateToken(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Email.ToString())
            });

            return user;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[32];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
