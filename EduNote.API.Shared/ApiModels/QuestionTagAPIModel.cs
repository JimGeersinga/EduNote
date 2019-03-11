using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Shared.ApiModels
{
    public class QuestionTagAPIModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TagId { get; set; }

    }
}
