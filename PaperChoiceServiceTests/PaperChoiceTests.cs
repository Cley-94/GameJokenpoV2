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
        private PaperChoiceService _paperChoiceService;

        public Tests()
        {
            var serviceCollection = new ServiceCollection();
            var choiceMock = new Mock<IChoiceService>();
            choiceMock.Setup(x => x.GetWinner(It.IsAny<ChoiceEnum>())).Returns(new ResultGameModel() { ResultadoEnum = ResultadoEnum.ComputerWins, ResultMessage = "Test Message" });
            serviceCollection.AddScoped<IChoiceService>(provider => choiceMock.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _paperChoiceService = new PaperChoiceService();
        }

        #region Check if user won/lost with paper
        [Test]
        public void User_Wins_With_Paper_Against_Rock()
        {
            ResultGameModel result = _paperChoiceService.GetWinner(ChoiceEnum.Pedra);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }

        [Test]
        public void User_Loses_With_Paper_Against_Scissor()
        {
            ResultGameModel result = _paperChoiceService.GetWinner(ChoiceEnum.Tesoura);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }
        #endregion
    }
}