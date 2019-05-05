using System;
using System.Collections.Generic;
using EduNote.API.Shared.ApiModels;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface IQuestionService
    {
        QuestionDetailDTO Get(int id);
        List<QuestionListDTO> FindBySection(int id);
        bool Put(QuestionDetailDTO vm);
        bool Post(QuestionDetailDTO vm);
    }
}
