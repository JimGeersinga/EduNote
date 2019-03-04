using EduNote.App.ViewModels;
using System.Collections.Generic;

namespace EduNote.App.Services
{
    public interface ISectionGroupService
    {
        IEnumerable<SectionGroupViewModel> All();
        SectionGroupViewModel Get(int id);
    }
}
