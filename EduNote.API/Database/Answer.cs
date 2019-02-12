using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduNote.API.Database
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public Question Question { get; set; }
    }
}