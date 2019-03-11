using System;

namespace EduNote.API.Shared.ApiModels
{
    public class AnswerAPIModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int QuestionId { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

    }
}