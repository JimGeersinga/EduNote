using Autofac;
using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduNote.App.MockServices
{
    public class SectionService : ISectionService
    {
        private readonly IApiService _apiService;

        public SectionService()
        {
            _apiService = App.Container.Resolve<IApiService>();
        }

        public async Task<IEnumerable<SectionListDTO>> GetRoot()
        {
            return await _apiService.Get<List<SectionListDTO>>("/sections/root");
        }

        public async Task<SectionDetailDTO> Get(long id)
        {
            return await _apiService.Get<SectionDetailDTO>($"/sections/{id}");
        }
    }
}
