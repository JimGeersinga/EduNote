using System.Collections.Generic;

namespace EduNote.API.Database
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}