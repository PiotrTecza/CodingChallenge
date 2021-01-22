using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Tests.Helpers;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountryDataServiceTests
    {
        private readonly Mock<ICountryDataClient> _countryDataClientMock = new Mock<ICountryDataClient>();

        private readonly List<Country> _countries;
        private CountryDataService _sut;

        public CountryDataServiceTests()
        {
            _countries = CountryHelper.GetCountries();

            _countryDataClientMock.Setup(x => x.GetAll()).ReturnsAsync(_countries);

            _sut = new CountryDataService(_countryDataClientMock.Object, new MemoryCache(new MemoryCacheOptions()), TimeSpan.FromSeconds(10));
        }

        [Fact]
        public async Task GetAll_OnInvoke_ReturnsListOfCountries()
        {
            // Arrange
            // Act
            var result = await _sut.GetAll();

            // Assert
            result.Should().BeEquivalentTo(_countries);
        }

        [Fact]
        public async Task GetAll_OnInvoke_CachesData()
        {
            // Arrange
            // Act
            await _sut.GetAll();
            await _sut.GetAll();

            // Assert
            _countryDataClientMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetAll_OnInvoke_FallsBackToSourceWhenCacheExpired()
        {
            // Arrange
            _sut = new CountryDataService(_countryDataClientMock.Object, new MemoryCache(new MemoryCacheOptions()), TimeSpan.FromMilliseconds(1));

            // Act
            await _sut.GetAll();
            await Task.Delay(2);
            await _sut.GetAll();

            // Assert
            _countryDataClientMock.Verify(x => x.GetAll(), Times.Exactly(2));
        }
    }
}
