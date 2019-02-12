using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduNote.API.Database
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Section> AllowedSections { get; set; }
    }
}