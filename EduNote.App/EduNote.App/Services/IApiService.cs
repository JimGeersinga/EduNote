using System.Threading.Tasks;

namespace EduNote.App.Services
{
    public interface IApiService
    {
        Task<T> Get<T>(string action);
        Task<T> Post<T>(string action, object data);
        Task<T> Put<T>(string action, object data);
        Task<T> Delete<T>(string action);
    }
}
