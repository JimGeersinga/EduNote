using System;
using System.Collections.Generic;
using EduNote.App.Services;
using EduNote.App.ViewModels;

namespace EduNote.App.MockServices
{
    public class MockQuestionService : IQuestionService
    {
        public List<QuestionViewModel> FindBySection(int id)
        {
            return new List<QuestionViewModel>();
        }

        public QuestionViewModel Get(int id)
        {
            return new QuestionViewModel();
        }

        public bool Post(QuestionViewModel vm)
        {
            return true;
        }

        public bool Put(QuestionViewModel vm)
        {
            return true;
        }
    }
}
