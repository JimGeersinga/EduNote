using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}