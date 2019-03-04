using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface ISectionService
    {
        IEnumerable<SectionViewModel> FindForSectionGroup(int id);
        SectionViewModel Get(int id);



    }
}
