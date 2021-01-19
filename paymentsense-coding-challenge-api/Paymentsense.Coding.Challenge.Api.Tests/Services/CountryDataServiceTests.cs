using FluentAssertions;
using Moq;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountryDataServiceTests
    {
        private readonly Mock<ICountryDataClient> _countryDataClientMock = new Mock<ICountryDataClient>();
        private readonly List<Country> _countries;
        private readonly CountryDataService _sut;

        public CountryDataServiceTests()
        {
            _countries = new List<Country>
            {
                new Country { Name = "UK", Flag = "http://flags.com/uk.svg"},
                new Country { Name = "USA", Flag = "http://flags.com/usa.svg"},
                new Country { Name = "Germany", Flag = "http://flags.comgermany.svg"},
            };

            _countryDataClientMock.Setup(x => x.GetAll()).ReturnsAsync(_countries);

            _sut = new CountryDataService(_countryDataClientMock.Object);
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
    }
}
