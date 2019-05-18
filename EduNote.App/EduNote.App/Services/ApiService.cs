using EduNote.App.Api;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EduNote.App.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient = DependencyService.Get<IEduHttpClient>().HttpClient();
        private readonly string _baseUrl;
        private string bearerToken = null;
        private string bearer
        {
            get
            {
                if(string.IsNullOrWhiteSpace(bearerToken) && Application.Current.Properties.ContainsKey("bearer"))
                {
                    bearerToken = Application.Current.Properties["bearer"] as string;
                }
                return bearerToken;
            }
        }


        public ApiService()
        {
            _baseUrl = StaticSettings.Settings.BaseUrl;
        }

        public async Task<T> Get<T>(string action)
        {
            try
            {
                authenticateRequest();
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
                authenticateRequest();
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
                authenticateRequest();
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
                authenticateRequest();
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

        private void authenticateRequest()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("bearer") && !string.IsNullOrWhiteSpace(bearer))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearer);
            }
        }

    }
}
