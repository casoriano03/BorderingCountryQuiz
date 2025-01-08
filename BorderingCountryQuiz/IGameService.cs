namespace BorderingCountryQuiz;

internal partial interface IGameService
{
    bool IsGameRunning { get; }
    List<string> CorrectCountriesGuessed { get; }
    int NumberCountriesToGuess { get; }
    int TriesCount { get; }
    void CheckAnswer(string answer, Country selectedCountry);
    void WinningOrLosingCondition(Country selectedCountry);
    void SetUpGameVariables(Country selectedCountry);
    void ShowGame(Country selectedCountry);
}