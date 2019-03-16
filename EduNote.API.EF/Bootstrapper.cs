using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Services;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using System;

namespace EduNote.API.EF
{
    public static class Bootstrapper
    {
        public static void Bootstrap(Container container, DbContextOptions<EduNoteContext> options)
        {
            container.Register<EduNoteContext>(() => new EduNoteContext(options), Lifestyle.Scoped);
            container.Register<IRepository, EFRepository<EduNoteContext>>(Lifestyle.Scoped);
        }
    }
}
