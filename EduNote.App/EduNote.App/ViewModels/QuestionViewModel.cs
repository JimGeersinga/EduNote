using System;
using Autofac;
using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;

namespace EduNote.App.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public QuestionViewModel() {
            _questionService = App.Container.Resolve<IQuestionService>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public int SectionId { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }

        private readonly IQuestionService _questionService;

        public void LoadQuestion(int questionId)
        {
            QuestionDetailDTO question = _questionService.Get(questionId);
            Id = question.Id;
            Title = question.Title;
            Body = question.Body;
            Created = question.Created;
            Modified = question.Modified;
            SectionId = question.SectionId;
            CreatedById = question.CreatedById;
            ModifiedById = question.ModifiedById;
        }
    }
}