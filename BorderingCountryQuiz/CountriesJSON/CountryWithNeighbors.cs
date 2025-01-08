using System.Text.Json;

namespace BorderingCountryQuiz.CountriesJSON
{
    public class CountryWithNeighbors
    {
        public string country { get; set; }
        public Neighbor[] neighbors { get; set; }

        public static CountryWithNeighbors[]  GetCountries()
        {
            var json = File.ReadAllText("CountriesJSON/countries.json");
            return JsonSerializer.Deserialize<CountryWithNeighbors[]>(json);
        }

        public string[] GetNeighbors()
        {
            return neighbors
                .Where(c => c.borderType.Contains("land"))
                .Select(n => n.country)
                .ToArray();
        }
    }
}
