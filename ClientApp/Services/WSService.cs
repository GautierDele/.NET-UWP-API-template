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

        public async static Task<MyEntity> GetMyEntityById(int id)
        {
            var response = await _client.GetAsync($"MyEntity/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<MyEntity>();
        }
    }
}
