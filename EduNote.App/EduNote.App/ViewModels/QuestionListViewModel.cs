using Autofac;
using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EduNote.App.ViewModels
{
    public class QuestionListViewModel : BaseViewModel
    {
        private QuestionDetailDTO _currentQuestion;
        public QuestionDetailDTO CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<QuestionListDTO> _questions;
        public ObservableCollection<QuestionListDTO> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        public QuestionListDTO SelectedQuestion { get; set; }

        public ICommand ItemTappedCommand { get; set; }
        public ICommand CreateQuestionCommand { get; set; }

        private readonly IQuestionService _questionService;
        private readonly INavigationService _navigationService;

        public QuestionListViewModel()
        {
            _navigationService = App.Container.Resolve<INavigationService>();
            _questionService = App.Container.Resolve<IQuestionService>();
            ItemTappedCommand = new RelayCommand(ItemTapped);
            CreateQuestionCommand = new RelayCommand(CreateCommand);
        }

        public void LoadQuestions()
        {
            Questions = new ObservableCollection<QuestionListDTO>(_questionService.FindBySection(1));
        }

        private async void ItemTapped()
        {
            if (SelectedQuestion != null)
            {
                //await _navigationService.ShowQuestion(SelectedQuestion.Id);
            }
        }

        private async void CreateCommand()
        {
            await _navigationService.ShowCreateQuestion();
        }


    }
}
