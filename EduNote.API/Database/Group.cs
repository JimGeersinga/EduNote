using System.Collections.Generic;

namespace EduNote.API.Database
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Section> AllowedSections { get; set; }
    }
}