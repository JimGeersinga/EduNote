using EduNote.App.ViewModels;
using System.Collections.Generic;

namespace EduNote.App.Services
{
    public interface ISectionService
    {
        IEnumerable<SectionViewModel> FindForSectionGroup(int id);
        SectionViewModel Get(int id);
    }
}
