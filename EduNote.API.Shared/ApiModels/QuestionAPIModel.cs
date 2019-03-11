using System;
using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class QuestionAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int SectionId { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

    }
}