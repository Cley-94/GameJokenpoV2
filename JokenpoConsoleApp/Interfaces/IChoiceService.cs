using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;

namespace JokenpoConsoleApp.Interfaces
{
    public interface IChoiceService 
    {
        ChoiceEnum GetEnumType();
        ResultGameModel GetWinner(ChoiceEnum choiceComputer);
    }
}
