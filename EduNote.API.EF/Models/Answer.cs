using System;

namespace EduNote.API.EF.Models
{
    public partial class Answer: BaseModel
    {
        public string Body { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}