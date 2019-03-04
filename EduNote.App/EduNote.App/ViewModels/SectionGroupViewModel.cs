using System;
using System.Collections.ObjectModel;
using Autofac;
using EduNote.App.Services;

namespace EduNote.App.ViewModels
{
    public class SectionGroupViewModel : BaseViewModel
    {
        public SectionGroupViewModel(string _title = "Default")
        {
            Title = _title;
            var sectionService = App.Container.Resolve<ISectionService>();
            Sections = new ObservableCollection<SectionViewModel>(sectionService.FindForSectionGroup(1)) ;
        }

        string title;
        public string Title
        {
            get
            {
                return string.IsNullOrWhiteSpace(title) ? "Null" : title;

            }
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
            get { return sections; }
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
