using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class Section : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int ParentId { get; set; }

        public Section Parent { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}