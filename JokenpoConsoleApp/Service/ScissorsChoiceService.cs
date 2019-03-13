using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Interfaces;
using JokenpoConsoleApp.Constantes;

namespace JokenpoConsoleApp.Service
{
    public class ScissorsChoiceService : IChoiceService
    {
        public ChoiceEnum GetEnumType()
        {
            return ChoiceEnum.Tesoura;
        }

        public ResultGameModel GetWinner(ChoiceEnum choiceComputer)
        {
            ResultGameModel resultGameModel = new ResultGameModel();

            if (choiceComputer == ChoiceEnum.Papel)
            {
                resultGameModel.ResultMessage = AnswerWinnerConst.MESSAGE_USER_WINS;
                resultGameModel.ResultadoEnum = ResultadoEnum.UserWins;
            }
            else if (choiceComputer == ChoiceEnum.Pedra)
            {
                resultGameModel.ResultMessage = AnswerWinnerConst.MESSAGE_CPU_WINS;
                resultGameModel.ResultadoEnum = ResultadoEnum.ComputerWins;
            }
            return resultGameModel;
        }
    }
}
