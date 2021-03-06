﻿using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class Question : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public long SectionId { get; set; }

        public Section Section { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTags> QuestionTags { get; set; }


        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }

        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
    }
}