using System;
using System.Collections.Generic;
using System.Linq;
using EduNote.API.Database;
using EduNote.API.Models;

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

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User FindByEmail(string email)
        {
            return context.Users.FirstOrDefault(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
