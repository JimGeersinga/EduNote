using System.Collections.Generic;

namespace EduNote.API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<NoteTags> NoteTags { get; set; }
        public ICollection<QuestionTags> QuestionTags { get; set; }
    }
}