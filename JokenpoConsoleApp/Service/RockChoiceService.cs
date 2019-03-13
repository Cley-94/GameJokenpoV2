using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Interfaces;
using JokenpoConsoleApp.Constantes;

namespace JokenpoConsoleApp.Service
{
    public class RockChoiceService : IChoiceService
    {
        public ChoiceEnum GetEnumType()
        {
            return ChoiceEnum.Pedra;
        }

        public ResultGameModel GetWinner(ChoiceEnum choiceComputer)
        {
            ResultGameModel resultGameModel = new ResultGameModel();

            if (choiceComputer == ChoiceEnum.Tesoura)
            {
                resultGameModel.ResultMessage = AnswerWinnerConst.MESSAGE_USER_WINS;
                resultGameModel.ResultadoEnum = ResultadoEnum.UserWins;
            }
            else if (choiceComputer == ChoiceEnum.Papel)
            {
                resultGameModel.ResultMessage = AnswerWinnerConst.MESSAGE_CPU_WINS;
                resultGameModel.ResultadoEnum = ResultadoEnum.ComputerWins;
            }
            return resultGameModel;
        }
    }
}
