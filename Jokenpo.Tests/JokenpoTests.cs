using NUnit.Framework;
using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Service;

namespace Tests
{
    [TestFixture]
    public class Tests 
    {
        private readonly JudgeService _judgeService;
        public Tests()
        {
            _judgeService = new JudgeService();
        }

        #region Check choices User
        [Test]
        public void Check_Choice_User_Rock()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("1");
            Assert.AreEqual(choiceUser.ChoiceEnum, ChoiceEnum.Pedra);
        }

        [Test]
        public void Check_Choice_User_Paper()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("2");
            Assert.AreEqual(choiceUser.ChoiceEnum, ChoiceEnum.Papel);
        }

        [Test]
        public void Check_Choice_User_Scissor()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("3");
            Assert.AreEqual(choiceUser.ChoiceEnum, ChoiceEnum.Tesoura);
        }

        [Test]
        public void User_Inserted_Unsupported_Value()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("teste jogo");
            Assert.AreEqual(choiceUser.ChoiceEnum, ChoiceEnum.ValorNaoSuportado);
        }
        #endregion

        #region Check choices Computer
        [Test]
        public void Check_Choice_Computer_Rock()
        {
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("1");
            Assert.AreEqual(choiceComputer.ChoiceEnum, ChoiceEnum.Pedra);
        }

        [Test]
        public void Check_Choice_Computer_Paper()
        {
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("2");
            Assert.AreEqual(choiceComputer.ChoiceEnum, ChoiceEnum.Papel);
        }

        [Test]
        public void Check_Choice_Computer_Scissor()
        {
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("3");
            Assert.AreEqual(choiceComputer.ChoiceEnum, ChoiceEnum.Tesoura);
        }
        #endregion

        #region Check winner Jokenpo Game
        #region When the user and the computer choose the same option
        [Test]
        public void Tie_User_And_Computer_Rock()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("1");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("1");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }

        [Test]
        public void Tie_User_And_Computer_Paper()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("2");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("2");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }

        [Test]
        public void Tie_User_And_Computer_Scissor()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("3");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("3");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }
        #endregion

        #region When the user chooses Rock
        [Test]
        public void User_Wins_With_Rock_Against_Scissor()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("1");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("3");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }

        [Test]
        public void User_Loses_With_Rock_Against_Paper()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("1");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("2");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }
        #endregion

        #region When the user chooses Paper
        [Test]
        public void User_Wins_With_Paper_Against_Rock()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("2");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("1");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }

        [Test]
        public void User_Loses_With_Paper_Against_Scissor()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("2");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("3");
            ResultGameModel result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }
        #endregion

        #region When the user chooses Scissor
        [Test]
        public void User_Loses_With_Scissor_Against_Rock()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("3");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("1");
            var result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }

        [Test]
        public void User_Wins_With_Scissor_Against_Paper()
        {
            ChoiceModel choiceUser = _judgeService.CheckChoicePlayers("3");
            ChoiceModel choiceComputer = _judgeService.CheckChoicePlayers("2");
            var result = _judgeService.JudgeDefinesWinner(choiceUser.ChoiceEnum.ToString(), choiceComputer.ChoiceEnum.ToString());
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }
        #endregion
        #endregion
    }
}