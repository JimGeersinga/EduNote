using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface ISectionGroupService
    {
        IEnumerable<SectionGroupViewModel> All();
        SectionGroupViewModel Get(int id);
    }
}
