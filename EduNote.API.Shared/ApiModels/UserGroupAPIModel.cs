using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Shared.ApiModels
{
    public class UserGroupAPIModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

    }
}
