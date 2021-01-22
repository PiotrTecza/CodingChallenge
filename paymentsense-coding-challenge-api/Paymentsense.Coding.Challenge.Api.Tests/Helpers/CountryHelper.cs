using System.Collections.Generic;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Tests.Helpers
{
    public class CountryHelper
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country
                {
                    Name = "USA",
                    Flag = "http://flags.com/usa.svg",
                    Population = 300000000,
                    Capital = "Washington",
                    Borders = new []{"Canada", "Mexico"},
                    Currencies = new []{new Currency { Code = "USD", Name = "US Dollar", Symbol = "$"} },
                    Languages = new []{new Language { Name = "english"}, new Language { Name = "spanish"} },
                    Timezones = new [] { "GMT-6", "GMT-7" }
                },
                new Country
                {
                    Name = "Canada",
                    Flag = "http://flags.com/canada.svg",
                    Population = 37500000,
                    Capital = "Ottawa",
                    Borders = new []{"USA"},
                    Currencies = new []{new Currency { Code = "CAD", Name = "Canadian Dollar", Symbol = "$"} },
                    Languages = new []{new Language { Name = "english"}, new Language { Name = "french"} },
                    Timezones = new [] { "GMT-6", "GMT-7" }
                }
            };
        }
    }
}
