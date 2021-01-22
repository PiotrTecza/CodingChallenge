using FluentAssertions;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Tests.Helpers;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryDataServiceTests
    {
        private readonly Mock<ICountryDataService> _countryDataServiceMock = new Mock<ICountryDataService>();
        private readonly List<Country> _countries;
        private readonly CountriesController _sut;

        public CountryDataServiceTests()
        {
            _countries = CountryHelper.GetCountries();

            _countryDataServiceMock.Setup(x => x.GetAll()).ReturnsAsync(_countries);

            _sut = new CountriesController(_countryDataServiceMock.Object);
        }

        [Fact]
        public async Task Get_OnInvoke_ReturnsListOfCountries()
        {
            // Arrange
            // Act
            var result = await _sut.Get();

            // Assert
            result.Should().BeEquivalentTo(_countries);
        }
    }
}
