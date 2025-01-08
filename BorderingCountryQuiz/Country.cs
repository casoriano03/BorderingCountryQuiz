using BorderingCountryQuiz.CountriesJSON;

namespace BorderingCountryQuiz
{
    internal class Country
    {
        public required string country { get; set; }
        public required string[] Neighbors { get; set; }
        
    }
}
