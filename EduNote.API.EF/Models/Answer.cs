using System;

namespace EduNote.API.EF.Models
{
    public partial class Answer: BaseModel
    {
        public string Body { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }


        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }

        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
    }
}