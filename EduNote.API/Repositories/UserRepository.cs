using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduNote.API.Database;
using EduNote.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EduNote.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EduNoteContext context;

        public UserRepository(EduNoteContext _context)
        {
            context = _context;
        }

        public IEnumerable<User> All()
        {
            return context.Users;
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
            return await context.Users.FirstOrDefaultAsync(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<User> Get(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
