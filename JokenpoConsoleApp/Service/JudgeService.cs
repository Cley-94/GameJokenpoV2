using System;
using System.Linq;
using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Interfaces;
using JokenpoConsoleApp.Constantes;
using Microsoft.Extensions.DependencyInjection;

namespace JokenpoConsoleApp.Service
{
    public class JudgeService : IJudgeService
    {
        ResultGameModel resultGameModel = new ResultGameModel();
        private IServiceProvider _serviceProvider;

        public JudgeService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ChoiceModel CheckChoicePlayers(string choicePlayers)
        {
            ChoiceModel choiceModel = new ChoiceModel();
            ChoiceEnum choiceValue;

            if (Enum.TryParse(choicePlayers, out choiceValue))
            {
                choiceModel.ChoiceEnum = choiceValue;
            }
            else
            {
                choiceModel.ErrorMessageWrongValue = "Opção de escolha indisponível. É necessário informar os valores '1', '2' ou '3' para jogar.\nPor favor, reinicie o jogo e tente novamente!";
                choiceModel.ChoiceEnum = ChoiceEnum.ValorNaoSuportado;
            }
            return choiceModel;
        }

        public ResultGameModel JudgeDefinesWinner(ChoiceEnum choicePlayer, ChoiceEnum choiceComputer)
        {
            string winner = string.Empty;

            if (choicePlayer == choiceComputer)
            {
                winner = AnswerWinnerConst.GAME_TIE;
                resultGameModel.ResultadoEnum = ResultadoEnum.Tie;
            }

            else
            {
                var services = _serviceProvider.GetServices<IChoiceService>();
                var service = services.First(x => x.GetEnumType() == choicePlayer);

                resultGameModel = service.GetWinner(choiceComputer);
            }
            resultGameModel.ResultMessage = "Você escolheu " + choicePlayer + " enquanto o computador escolheu "
                + choiceComputer + ", portanto, " + resultGameModel.ResultMessage;
            return resultGameModel;
        }
    }
}
