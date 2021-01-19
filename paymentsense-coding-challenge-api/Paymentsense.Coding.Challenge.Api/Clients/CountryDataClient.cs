using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public class CountryDataClient : ICountryDataClient
    {
        private readonly HttpClient _client;

        public CountryDataClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Country>> GetAll()
        {
            var response = await _client.GetAsync("all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Country>>(content);
        }
    }
}
