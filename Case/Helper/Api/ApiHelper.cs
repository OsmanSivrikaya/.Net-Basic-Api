using System.Net.Http;

namespace Case.Helper.Api
{
    public class ApiHelper : IApiHelper
    {
        private readonly HttpClient _httpClient;
        public ApiHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            return null;
        }
    }
}
