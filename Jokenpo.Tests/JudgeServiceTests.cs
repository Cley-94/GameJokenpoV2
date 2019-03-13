using Moq;
using NUnit.Framework;
using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Service;
using JokenpoConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private JudgeService _judgeService;

        public Tests()
        {
            var serviceCollection = new ServiceCollection();
            var choiceMock = new Mock<IChoiceService>();
            choiceMock.Setup(x => x.GetEnumType()).Returns(ChoiceEnum.Pedra);
            choiceMock.Setup(x => x.GetWinner(It.IsAny<ChoiceEnum>())).Returns(new ResultGameModel() { ResultadoEnum = ResultadoEnum.ComputerWins, ResultMessage = "Test Message" });
            serviceCollection.AddScoped<IChoiceService>(provider => choiceMock.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _judgeService = new JudgeService(serviceProvider);
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
        
        #region When the user and the computer choose the same option

        [Test]
        public void Game_Tie_User_And_Computer_Rock()
        {
            ResultGameModel result = _judgeService.JudgeDefinesWinner(ChoiceEnum.Pedra, ChoiceEnum.Pedra);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }

        [Test]
        public void Tie_User_And_Computer_Paper()
        {
            ResultGameModel result = _judgeService.JudgeDefinesWinner(ChoiceEnum.Papel, ChoiceEnum.Papel);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }

        [Test]
        public void Tie_User_And_Computer_Scissor()
        {
            ResultGameModel result = _judgeService.JudgeDefinesWinner(ChoiceEnum.Tesoura, ChoiceEnum.Tesoura);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }

        [Test]
        public void Not_Game_Tie()
        {
            ResultGameModel result = _judgeService.JudgeDefinesWinner(ChoiceEnum.Pedra, ChoiceEnum.Papel);
            Assert.AreNotEqual(result.ResultadoEnum, ResultadoEnum.Tie);
        }
        #endregion
    }
}