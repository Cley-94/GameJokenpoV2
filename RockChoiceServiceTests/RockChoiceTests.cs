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
        private RockChoiceService _rockChoiceService;

        public Tests()
        {
            var serviceCollection = new ServiceCollection();
            var choiceMock = new Mock<IChoiceService>();
            choiceMock.Setup(x => x.GetWinner(It.IsAny<ChoiceEnum>())).Returns(new ResultGameModel() { ResultadoEnum = ResultadoEnum.ComputerWins, ResultMessage = "Test Message"});
            serviceCollection.AddScoped<IChoiceService>(provider => choiceMock.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _rockChoiceService = new RockChoiceService();
        }

        #region Check if user won/lost with rock 
        [Test]
        public void User_Wins_With_Rock_Against_Scissor()
        {
            ResultGameModel result = _rockChoiceService.GetWinner(ChoiceEnum.Tesoura);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.UserWins);
        }

        [Test]
        public void User_Loses_With_Rock_Against_Paper()
        {
            ResultGameModel result = _rockChoiceService.GetWinner(ChoiceEnum.Papel);
            Assert.AreEqual(result.ResultadoEnum, ResultadoEnum.ComputerWins);
        }
        #endregion
    }
}