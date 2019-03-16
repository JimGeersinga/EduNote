using System;

namespace EduNote.API.EF.Models
{
    public partial class Answer: BaseModel
    {
        public string Body { get; set; }

        public long QuestionId { get; set; }

        public Question Question { get; set; }
        
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }

        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
    }
}