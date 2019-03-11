using System;
using System.Collections.Generic;
using EduNote.App.Services;
using EduNote.App.ViewModels;

namespace EduNote.App.MockServices
{
    public class MockNoteService : INoteService
    {

        public NoteViewModel Get(int id)
        {
            return new NoteViewModel();
        }

        public List<NoteViewModel> GetForSection(int id)
        {
            return new List<NoteViewModel>();
        }

        public bool Post(NoteViewModel vm)
        {
            return true;
        }

        public bool Put(NoteViewModel vm)
        {
            return true;
        }
    }
}
