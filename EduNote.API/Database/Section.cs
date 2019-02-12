using System.Collections.Generic;

namespace EduNote.API.Database
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Section ParentSection { get; set; }
        public virtual ICollection<User> AllowedUsers { get; set; }
        public virtual ICollection<Group> AllowedGroups { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}