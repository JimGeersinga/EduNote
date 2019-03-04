using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduNote.API.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ParentId { get; set; }
        
        public Section Parent { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}