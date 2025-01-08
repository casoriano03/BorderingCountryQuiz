using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BorderingCountryQuiz.CountriesJSON
{
    internal class CountriesDataService: ICountriesDataService
    {
        public List<string>? ReadCountryCodeJson()
        {
            var json = File.ReadAllText("CountriesJSON/countryCodes.json");
            var countriesWithCodes = JsonSerializer.Deserialize<string[]>(json).ToList();
            return countriesWithCodes;
        }

        public List<CountryWithNeighbors> FilterCountriesData(List<string>? countriesWithCodes)
        {
            var filteredCountries = new List<CountryWithNeighbors>();
            foreach (var country in CountryWithNeighbors.GetCountries())
            {
                var matchExists = countriesWithCodes != null && countriesWithCodes.Any(code =>
                    string.Equals(code, country.country, StringComparison.OrdinalIgnoreCase));

                if (matchExists)
                {
                    filteredCountries.Add(country);
                }
            }
            return filteredCountries;
        }
    }
}
