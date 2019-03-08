using System;
using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Interfaces;

namespace JokenpoConsoleApp.Service
{
    public class JudgeService : IJudgeService
    {
        private readonly string MESSAGE_USER_WINS = "você é o vencedor! Parabéns!";
        private readonly string MESSAGE_CPU_WINS = "o computador é o vencedor!";
        private readonly string GAME_TIE = "houve empate no jogo!";
        ResultGameModel resultGameModel = new ResultGameModel();

        public ChoiceModel CheckChoicePlayers(string choicePlayers)
        {
            ChoiceModel choiceModel = new ChoiceModel();
            ChoiceEnum choiceValue;

            if (Enum.TryParse(choicePlayers, out choiceValue))/*TryParse retorna um boolean informando se  a conversão foi bem sucedida. 
                A variável marcada com "out"(choiceValue) é quem vai receber o valor convertido para o seu respectivo tipo(ChoiceEnum).
                Pro caso do enum, a busca sempre vai ser feita em todas as chaves e valores do tipo
                de enum especificado(ChoiceEnum). Chave(Pedra) = Valor(1)*/ 
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

        public ResultGameModel JudgeDefinesWinner(string choicePlayer, string choiceComputer)
        {
            string winner = string.Empty;

            if (choicePlayer == choiceComputer)
            {
                winner = GAME_TIE;
                resultGameModel.ResultadoEnum = ResultadoEnum.Tie;
            }

            if (choicePlayer == "Pedra")
            {
                if(choiceComputer == "Tesoura")
                {
                    winner = MESSAGE_USER_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.UserWins;
                }
                if (choiceComputer == "Papel")
                {
                    winner = MESSAGE_CPU_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.ComputerWins;
                }
            }

            if(choicePlayer == "Papel")
            {
                if(choiceComputer == "Pedra")
                {
                    winner = MESSAGE_USER_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.UserWins;
                }
                if (choiceComputer == "Tesoura")
                {
                    winner = MESSAGE_CPU_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.ComputerWins;
                }
            }

            if(choicePlayer == "Tesoura")
            {
                if(choiceComputer == "Pedra")
                {
                    winner = MESSAGE_CPU_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.ComputerWins;
                }
                if (choiceComputer == "Papel")
                {
                    winner = MESSAGE_USER_WINS;
                    resultGameModel.ResultadoEnum = ResultadoEnum.UserWins;
                }
            }
            resultGameModel.ResultMessage = "Você escolheu " + choicePlayer + " enquanto o computador escolheu "
                + choiceComputer + ", portanto, " + winner;
            return resultGameModel;
        }
    }
}
