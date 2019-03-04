using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public class MockSectionGroupService : ISectionGroupService
    {


        public IEnumerable<SectionGroupViewModel> All()
        {
            return new List<SectionGroupViewModel> { new SectionGroupViewModel ("Section 1" ), new SectionGroupViewModel { Title = "Section 2" } };
        }

        public SectionGroupViewModel Get(int id)
        {
            return new SectionGroupViewModel("Section "+id.ToString()) ;
        }
    }
}
