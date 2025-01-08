using System.Diagnostics;
using BorderingCountryQuiz.CountriesJSON;

namespace BorderingCountryQuiz
{
    internal class App
    {
        private readonly IGameService _gameService;
        private readonly ICountriesDataService _countriesDataService;
        private readonly ICountryService _countryService;

       public App(ICountryService countryService, IGameService gameService, ICountriesDataService countriesDataService)
        {
            _countryService = countryService;
            _gameService = gameService;
            _countriesDataService = countriesDataService;
        }

        public void Run()
        {
            var countriesJson = _countriesDataService.ReadCountryCodeJson();
            var filteredCountries = _countriesDataService.FilterCountriesData(countriesJson);
            foreach (var country in filteredCountries)
            {
                _countryService.AddCountry(country.country, country.GetNeighbors());
            }
            var selectedCountry = _countryService.SelectRandomCountry();
            _gameService.SetUpGameVariables(selectedCountry);

            while (_gameService.IsGameRunning)
            {
                //cheat code
                Console.WriteLine($"{selectedCountry.country}");
                foreach (var neighbor in selectedCountry.Neighbors)
                {
                    Console.WriteLine($"-{neighbor}");
                }
                // 

                _gameService.ShowGame(selectedCountry);
                var answer = _countryService.AskForNeighborsOfRandomCountry();
                _gameService.CheckAnswer(answer, selectedCountry);
                _gameService.WinningOrLosingCondition(selectedCountry);
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
    }
}
