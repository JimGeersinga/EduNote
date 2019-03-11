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
        User Get(int id);
        User FindByEmail(string email);

        User Create(User user);
        User Update(User user);

        bool Delete(int id);
    }
}
