using JokenpoConsoleApp.Model;

namespace JokenpoConsoleApp.Interfaces
{
    public interface IJudgeService
    {
        ChoiceModel CheckChoicePlayers(string choicePlayers);
        ResultGameModel JudgeDefinesWinner(string choicePlayer, string choiceComputer);
    }
}
