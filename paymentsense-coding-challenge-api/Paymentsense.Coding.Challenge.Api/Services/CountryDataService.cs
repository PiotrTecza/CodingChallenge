using Microsoft.Extensions.Caching.Memory;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Constants;
using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly ICountryDataClient _countryDataClient;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _cacheDuration;

        public CountryDataService(ICountryDataClient countryDataClient, IMemoryCache memoryCache, TimeSpan cacheDuration)
        {
            _countryDataClient = countryDataClient;
            _memoryCache = memoryCache;
            _cacheDuration = cacheDuration;
        }

        public async Task<List<Country>> GetAll() => await GetCountries();

        private async Task<List<Country>> GetCountries()
        {
            return await _memoryCache.GetOrCreateAsync(CacheKeyConstants.Countries, c =>
            {
                c.AbsoluteExpirationRelativeToNow = _cacheDuration;
                return _countryDataClient.GetAll();
            });
        }
    }
}
