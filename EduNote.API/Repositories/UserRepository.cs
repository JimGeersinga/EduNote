using EduNote.API.Database;
using EduNote.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduNote.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EduNoteContext _context;
        private readonly AppSettings _appSettings;

        public UserRepository(EduNoteContext context, AppSettings appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public IEnumerable<User> All()
        {
            return _context.Users;
        }

        public async Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string email, string password)
        {
            User user = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);
            if (user == null)
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            _context.SaveChanges();

             return user;
        }
    }
}
