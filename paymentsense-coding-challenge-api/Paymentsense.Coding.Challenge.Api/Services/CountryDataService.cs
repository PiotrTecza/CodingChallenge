using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly ICountryDataClient _countryDataClient;

        public CountryDataService(ICountryDataClient countryDataClient)
        {
            _countryDataClient = countryDataClient;
        }

        public async Task<List<Country>> GetAll() => await _countryDataClient.GetAll();
    }
}
