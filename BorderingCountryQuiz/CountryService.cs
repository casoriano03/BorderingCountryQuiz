using BorderingCountryQuiz.CountriesJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderingCountryQuiz
{
    internal class CountryService:ICountryService 
    {
        private readonly List<Country> _countriesToGuess = new();

        public void AddCountry(string countryName, string[] neighboringCountryNames)
        {
            var countryExistsCheck = _countriesToGuess.Find(c => c.country == countryName);
            if (countryExistsCheck != null) return;
            var newCountry = new Country()
            {
                country = countryName,
                Neighbors = neighboringCountryNames
            };
            _countriesToGuess.Add(newCountry);
            AddNeighborCountries(neighboringCountryNames);
        }

        public void AddNeighborCountries(string[] neighboringCountryNames)
        {
            var countryArray = CountryWithNeighbors.GetCountries();
            foreach (var neighboringCountry in neighboringCountryNames)
            {
                var countryExistsCheck = _countriesToGuess.Find(c => c.country == neighboringCountry);
                if (countryExistsCheck != null) continue;
                var missingNeighborCountry = countryArray.FirstOrDefault(c => c.country == neighboringCountry);
                if (missingNeighborCountry == null) continue;
                var newCountry = new Country
                {
                    country = neighboringCountry,
                    Neighbors = missingNeighborCountry.GetNeighbors()

                };
                _countriesToGuess.Add(newCountry);
            }
        }

        public string AskForNeighborsOfRandomCountry()
        {
            var countryCodeConsole = new CountryCodeConsole("Velg et land: ");
            var countryName = countryCodeConsole.AskForCountry();
            Console.WriteLine(countryName);
            return countryName;
        }

        public Country SelectRandomCountry()
        {
            var random = new Random();
            var isNotQualifiedCountry = true;
            Country country = null!;
            while (isNotQualifiedCountry)
            {
                var randomCountry = _countriesToGuess[random.Next(0, _countriesToGuess.Count - 1)];
                if (randomCountry.Neighbors.Length != 0) isNotQualifiedCountry = false;
                country = randomCountry;
            }
            return country;
        }
    }
}
