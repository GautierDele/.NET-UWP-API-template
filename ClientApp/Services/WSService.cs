using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models.EntityFramework;

namespace ClientApp
{
    class WSService
    {
        static HttpClient _client;

        public WSService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        public async static Task<Telephone> GetTelephoneByReference(string reference)
        {
            var response = await _client.GetAsync($"Telephone/ByReference/{reference}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<Telephone>();
        }
    }
}
