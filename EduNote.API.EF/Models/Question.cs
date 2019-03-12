using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class Question : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTags> QuestionTags { get; set; }
    }
}