using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduNote.API.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int QuestionId { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

        public Question Question { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}