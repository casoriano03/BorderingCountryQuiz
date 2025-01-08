namespace BorderingCountryQuiz;

internal interface ICountryService
{
    string AskForNeighborsOfRandomCountry();
    void AddCountry(string countryName, string[] neighboringCountryNames);
    void AddNeighborCountries(string[] neighboringCountryNames);
    Country SelectRandomCountry();
}