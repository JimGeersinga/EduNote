using Autofac;
using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EduNote.App.ViewModels
{
    public class SectionListViewModel : BaseViewModel
    {
        private SectionDetailDTO _currentSection;
        public SectionDetailDTO CurrentSection
        {
            get => _currentSection;
            set
            {
                _currentSection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SectionListDTO> _sections;
        public ObservableCollection<SectionListDTO> Sections
        {
            get => _sections;
            set
            {
                _sections = value;
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

        private ObservableCollection<NoteDTO> _notes;
        public ObservableCollection<NoteDTO> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public SectionListDTO SelectedSection { get; set; }

        public ICommand ItemTappedCommand { get; set; }

        private readonly ISectionService _sectionService;
        private readonly INavigationService _navigationService;

        public SectionListViewModel()
        {
            _navigationService = App.Container.Resolve<INavigationService>();
            _sectionService = App.Container.Resolve<ISectionService>();
            ItemTappedCommand = new RelayCommand(ItemTapped);
        }

        public async void LoadSections(long? sectionId)
        {
            if (sectionId == null)
            {
                CurrentSection = new SectionDetailDTO() { Title = "Secties" };
                Sections = new ObservableCollection<SectionListDTO>(await _sectionService.GetRoot());
            }
            else
            {
                CurrentSection = await _sectionService.Get(sectionId.Value);
                Sections = new ObservableCollection<SectionListDTO>(CurrentSection.Sections);
                Questions = new ObservableCollection<QuestionListDTO>(CurrentSection.Questions);
                Notes = new ObservableCollection<NoteDTO>(CurrentSection.Notes);
            }
        }

        private async void ItemTapped()
        {
            if (SelectedSection != null)
            {
                await _navigationService.ShowSectionList(SelectedSection.Id);
            }
        }
    }
}
