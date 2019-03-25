using EduNote.API.Shared.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduNote.App.Services
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionListDTO>> GetRoot();
        Task<SectionDetailDTO> Get(long id);
    }
}
