using EduNote.App.ViewModels;
﻿using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface IQuestionService
    {
        QuestionViewModel Get(int id);
        List<QuestionViewModel> FindBySection(int id);
        bool Put(QuestionViewModel vm);
        bool Post(QuestionViewModel vm);

    }
}
