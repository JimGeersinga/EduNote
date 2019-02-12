using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduNote.API.Database
{
    public class Section
    {
        public int SectionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Section ParentSection { get; set; }
        public ICollection<User> AllowedUsers { get; set; }
        public ICollection<Group> AllowedGroups { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}