using System.Collections.Generic;

namespace EduNote.API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserGroups> UserGroups { get; set; }
    }
}