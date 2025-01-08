using BorderingCountryQuiz.CountriesJSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BorderingCountryQuiz
{
    internal class GameService : IGameService
    {
        public bool IsGameRunning { get; private set; } = true;
        public List<string> CorrectCountriesGuessed { get; private set; } = new List<string>();
        public int NumberCountriesToGuess { get; private set; } = 0;
        public int TriesCount { get; private set; }= 5;
        private List<string>? _neighborCountriesToGuess;
        private int _numberCorrectGuess = 0;


        public void SetUpGameVariables(Country selectedCountry)
        {
            NumberCountriesToGuess = selectedCountry.Neighbors.Length;
            _neighborCountriesToGuess = selectedCountry.Neighbors.ToList();
        }

        public bool CheckAnswer(string answer, Country selectedCountry)
        {
            var answerExists = selectedCountry.Neighbors
                .Any(neighbor => neighbor.Contains(answer) || neighbor == answer);
         
            return answerExists;
        }

        public void UpdateGameVariables(bool answerExists, string answer)
        {

            if (answerExists)
            {
                NumberCountriesToGuess--;
                _numberCorrectGuess++;
                CorrectCountriesGuessed.Add(answer);
                if (_neighborCountriesToGuess != null) _neighborCountriesToGuess.Remove(answer);
                Console.WriteLine($"Du har gjettet riktig!");
            }
            else
            {
                Console.WriteLine($"Svaret er feil! Gjett et annet land");
                TriesCount--;
            }
        }

        public void ShowGame(Country selectedCountry)
        {
            Console.Clear();
            Console.WriteLine($"Gjett nabolandene til {selectedCountry.country}");
            Console.WriteLine($"Landene du klarte å gjette:");
            foreach (var country in CorrectCountriesGuessed)
            {
                Console.WriteLine($"-{country}");
            }
            Console.WriteLine($"Du mangler {NumberCountriesToGuess} land.");
            Console.WriteLine($"Du har {TriesCount} feil forsøk");
        }

        public void WinningOrLosingCondition(Country selectedCountry)
        {
            if (TriesCount <= 0)
            {
                Console.WriteLine($"Du har ingen forsøk lenger. \n Vil du fortsette? Tast - Y \n Vil du begynne på nytt? Tast - R  \n Avslutte? Trykk - Enter");
                var decision = Console.ReadLine();
                if (decision?.ToUpper() == "R")
                {
                    IsGameRunning = !IsGameRunning;
                    RestartApplication();
                }
                else if (decision?.ToUpper() == "Y")
                {
                    IsGameRunning = true;
                }
                else
                {
                    QuitGame();
                }
            }

            if (_numberCorrectGuess == selectedCountry.Neighbors.Length)
            {
                Console.WriteLine($"Gratulerer! Du har gjettet alle nabolandene.");
                Console.WriteLine($"Vil du begynne på nytt? Tast - R  \n Avslutte? Trykk - Enter");
                var decision = Console.ReadLine();
                if (decision?.ToUpper() == "R")
                {
                    IsGameRunning = !IsGameRunning;
                    ShowUnidentifiedCountries();
                    RestartApplication();
                }
                else
                {
                    ShowUnidentifiedCountries();
                    QuitGame();
                }
            }
        }

        private void QuitGame()
        {
            IsGameRunning = !IsGameRunning;
           
        }

        private void RestartApplication()
        {
            var appPath = Process.GetCurrentProcess().MainModule!.FileName;
            Process.Start(appPath);
            Environment.Exit(0);
        }

        private void ShowUnidentifiedCountries()
        {
            Console.WriteLine("Landene du klarte ikke å gjette:");
            if (_neighborCountriesToGuess != null)
                foreach (var neighbor in _neighborCountriesToGuess)
                {
                    Console.WriteLine($"{neighbor}");
                }
        }
    }
}
