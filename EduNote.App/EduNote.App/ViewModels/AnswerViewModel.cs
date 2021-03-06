﻿using System;
namespace EduNote.App.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public int QuestionId { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
    }
}
