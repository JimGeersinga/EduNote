using EduNote.App.ViewModels;
using System.Collections.Generic;

namespace EduNote.App.Services
{
    public interface ISectionGroupService
    {
        IEnumerable<SectionListViewModel> All();
        SectionListViewModel Get(int id);
    }
}
