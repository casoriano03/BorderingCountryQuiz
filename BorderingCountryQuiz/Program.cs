using BorderingCountryQuiz;
using BorderingCountryQuiz.CountriesJSON;


ICountryService countryService = new CountryService();
IGameService gameService = new GameService();
ICountriesDataService countriesDataService = new CountriesDataService();


var app = new App(countryService, gameService, countriesDataService);
app.Run();

