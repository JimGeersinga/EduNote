using Autofac;
using EduNote.App.Services;
using System.Collections.ObjectModel;

namespace EduNote.App.ViewModels
{
    public class SectionGroupViewModel : BaseViewModel
    {
        public SectionGroupViewModel(string _title = "Default")
        {
            Title = _title;
            ISectionService sectionService = App.Container.Resolve<ISectionService>();
            Sections = new ObservableCollection<SectionViewModel>(sectionService.FindForSectionGroup(1));
        }

        private string title;
        public string Title
        {
            get => string.IsNullOrWhiteSpace(title) ? "Null" : title;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    title = value;
                    OnPropertyChanged();
                }

            }
        }

        private ObservableCollection<SectionViewModel> sections { get; set; }
        public ObservableCollection<SectionViewModel> Sections
        {
            get => sections;
            set
            {
                sections = value;
                OnPropertyChanged();
            }
        }

        //ObservableCollection<SectionViewModel> sections;
        //public object MyProperty { get; set; }


    }
}
