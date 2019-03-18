using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class GroupDetailDTO: GroupListDTO
    {
        public UserListDTO Users { get; set; }
    }
}