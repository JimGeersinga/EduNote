using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface IQuestionService
    {
        QuestionDetailsViewModel Get(int id);
    }
}