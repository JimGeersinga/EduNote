using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class Tag : BaseModel
    {
        public string Name { get; set; }

        public ICollection<NoteTags> NoteTags { get; set; }
        public ICollection<QuestionTags> QuestionTags { get; set; }
    }
}