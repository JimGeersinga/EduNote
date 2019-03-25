using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EduNote.App.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl;

        public ApiService()
        {
            _baseUrl = "http://localhost:50900/api";
        }

        public async Task<T> Get<T>(string action)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + action);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Post<T>(string action, object data)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl + action, content);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Put<T>(string action, object data)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(_baseUrl + action, content);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Delete<T>(string action)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(_baseUrl + action);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
