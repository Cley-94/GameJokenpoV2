using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;

namespace JokenpoConsoleApp.Interfaces
{
    public interface IJudgeService
    {
        ChoiceModel CheckChoicePlayers(string choicePlayers);
        ResultGameModel JudgeDefinesWinner(ChoiceEnum choicePlayer, ChoiceEnum choiceComputer);
    }
}
