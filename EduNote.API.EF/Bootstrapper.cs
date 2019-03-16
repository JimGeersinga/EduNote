using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Services;
using SimpleInjector;
using System;

namespace EduNote.API.EF
{
    public static class Bootstrapper
    {
        public static void Bootstrap(Container container)
        {
            container.Register<EduNoteContext>(() => new EduNoteContext(), Lifestyle.Scoped);
            container.Register<IRepository, EFRepository<EduNoteContext>>(Lifestyle.Scoped);
        }
    }
}
