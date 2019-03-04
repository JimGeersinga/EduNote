using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public class MockSectionService : ISectionService
    {


        public IEnumerable<SectionViewModel> FindForSectionGroup(int id)
        {
            return new List<SectionViewModel> { 
                new SectionViewModel{Title="Dev " + id.ToString(), Subtitle = "Jesse Tjang"},
                new SectionViewModel{Title="Ana " + id.ToString(), Subtitle = "Jos Francken"}
            };
        }

        public SectionViewModel Get(int id)
        {
            return new SectionViewModel { Title = "Dev " + id.ToString(), Subtitle = "Jesse Tjang" };
        }
    }
}
