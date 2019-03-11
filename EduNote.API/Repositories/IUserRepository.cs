using EduNote.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> All();
        Task<User> Get(int id);
        Task<User> FindByEmail(string email);

        Task<User> Create(User user);
        Task<User> Update(User user);

        Task<bool> Delete(int id);
    }
}
