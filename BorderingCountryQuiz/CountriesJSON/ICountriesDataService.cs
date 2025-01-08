namespace BorderingCountryQuiz.CountriesJSON;

internal interface ICountriesDataService
{
    List<string>? ReadCountryCodeJson();
    List<CountryWithNeighbors> FilterCountriesData(List<string>? countriesWithCodes);
}