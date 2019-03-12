using System;

namespace EduNote.API.EF
{
    public static class Bootstrapper
    {
        public static void Bootstrap(Container container)
        {
            container.Register<HCMSROCATEQCASTERV2Context>(() => new HCMSROCATEQCASTERV2Context(), Lifestyle.Scoped);
            container.Register<IRepository, EFRepository<HCMSROCATEQCASTERV2Context>>(Lifestyle.Scoped);
        }
    }
}
