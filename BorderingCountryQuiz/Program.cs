using BorderingCountryQuiz;
using BorderingCountryQuiz.CountriesJSON;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<ICountriesDataService, CountriesDataService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<App>();

var host = builder.Build();

var app = host.Services.GetRequiredService<App>();
app.Run();


//ICountryService countryService = new CountryService();
//IGameService gameService = new GameService();
//ICountriesDataService countriesDataService = new CountriesDataService();


//var app = new App(countryService, gameService, countriesDataService);
//app.Run();

