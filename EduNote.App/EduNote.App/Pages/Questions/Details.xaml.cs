using Autofac;
using EduNote.App.Services;
using EduNote.App.ViewModels;
using Xamarin.Forms;

namespace EduNote.App.Pages.Questions
{
    public partial class Details : ContentPage
    {
        public Details() 
        {
            InitializeComponent();
            IQuestionService service = App.Container.Resolve<IQuestionService>();
            QuestionDetailsViewModel model = service.Get(4);
            BindingContext = model;
        }

        public Details(int id = 1)
        {
            InitializeComponent();
            IQuestionService service = App.Container.Resolve<IQuestionService>();
            QuestionDetailsViewModel model = service.Get(id);
            BindingContext = model;
        }
    }
}