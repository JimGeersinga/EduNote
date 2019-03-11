using System;
using System.Collections.Generic;
using EduNote.App.ViewModels;

namespace EduNote.App.Services
{
    public interface INoteService
    {
        bool Post(NoteViewModel vm);
        List<NoteViewModel> GetForSection(int id);
        NoteViewModel Get(int id);
        bool Put(NoteViewModel vm);
    }
}
