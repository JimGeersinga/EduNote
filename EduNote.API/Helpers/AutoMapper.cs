using AutoMapper;
using EduNote.API.Profiles;

namespace EduNote.API.Helpers
{
    public class AutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
        }
    }
}
