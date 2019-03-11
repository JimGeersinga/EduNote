using EduNote.App.Services;
using EduNote.App.ViewModels;
using System.Collections.Generic;

namespace EduNote.App.MockServices
{
    public class MockSectionGroupService : ISectionGroupService
    {
        public IEnumerable<SectionGroupViewModel> All()
        {
            return new List<SectionGroupViewModel>()
            {
                new SectionGroupViewModel("Section 1"),
                new SectionGroupViewModel("Section 2")
            };
        }

        public SectionGroupViewModel Get(int id)
        {
            return new SectionGroupViewModel("Section " + id.ToString());
        }
    }
}
