using Moq;
using NUnit.Framework;
using JokenpoConsoleApp.Enums;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Service;
using JokenpoConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class Tests
    {
        private ScissorsChoiceService _scissorsChoiceService;
        public Tests()
        {
            var serviceCollection = new ServiceCollection();
            var choiceMock = new Mock<IChoiceService>();
            choiceMock.Setup(x => x.GetWinner(It.IsAny<ChoiceEnum>())).Returns(new ResultGameModel() { ResultadoEnum = ResultadoEnum.ComputerWins, ResultMessage = "Test Message" });
            serviceCollection.AddScoped<IChoiceService>(provider => choiceMock.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _scissorsChoiceService = new ScissorsChoiceService();
        }

        #region Check if user won/lost with scissors
        [Test]
        public void User_Wins_With_Scissor_Against_Paper()
        {
            ResultGameModel result = _scissorsChoiceService.GetWinner(ChoiceEnum.Papel);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }

        [Test]
        public void User_Loses_With_Scissor_Against_Rock()
        {
            ResultGameModel result = _scissorsChoiceService.GetWinner(ChoiceEnum.Pedra);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }
        #endregion
    }
}