using System;
using System.Collections.Generic;
using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;
using EduNote.App.ViewModels;

namespace EduNote.App.MockServices
{
    public class MockQuestionService : IQuestionService
    {
        public List<QuestionListDTO> FindBySection(int id)
        {
            return new List<QuestionListDTO>()
            {
                new QuestionListDTO()
                {
                    Id=1,
                    Title="Testquestion 1",
                    Body="Tis is the body of question 1.",
                },
                new QuestionListDTO()
                {
                    Id=2,
                    Title="Testquestion 2",
                    Body="Tis is the body of question 2.",
                }
            };
        }

        public QuestionDetailDTO Get(int id)
        {
            return new QuestionDetailDTO();
        }

        public bool Post(QuestionDetailDTO vm)
        {
            return true;
        }

        public bool Put(QuestionDetailDTO vm)
        {
            return true;
        }
    }
}
