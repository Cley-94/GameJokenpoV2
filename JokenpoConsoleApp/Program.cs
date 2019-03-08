using System;
using System.ComponentModel;
using JokenpoConsoleApp.Model;
using JokenpoConsoleApp.Service;
using JokenpoConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JokenpoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup DI
            var serviceProvider = new ServiceCollection()
            .AddScoped<IJudgeService, JudgeService>()
            .BuildServiceProvider();
            var judgeResult = serviceProvider.GetService<IJudgeService>();

            string choiceUser = null;
            string choiceCPU = null;
            Random rdn = new Random();
            
            Console.WriteLine("Olá, seja bem vindo ao jogo de Jokenpoo!");
            Console.WriteLine("As regras são as seguintes: \n" +
                              "   - Pedra empata com pedra e ganha de tesoura; \n" +
                              "   - Tesoura empata com tesoura e ganha de papel; \n" +
                              "   - Papel empata com papel e ganha de pedra.");

            Console.WriteLine("Para começarmos, digite '1' para 'Pedra', '2' para 'Papel' ou '3' para 'Tesoura':");
            choiceUser = Console.ReadLine();

            ChoiceModel verifyChoiceUser = judgeResult.CheckChoicePlayers(choiceUser);
            if (verifyChoiceUser.ChoiceEnum.ToString() != "Pedra" && verifyChoiceUser.ChoiceEnum.ToString() != "Papel" && verifyChoiceUser.ChoiceEnum.ToString() != "Tesoura")
            {
                Console.WriteLine(verifyChoiceUser.ErrorMessageWrongValue);
            }
            else
            {
                choiceCPU = rdn.Next(1, 3).ToString();
                var verifyChoiceCPU = judgeResult.CheckChoicePlayers(choiceCPU);

                var result = judgeResult.JudgeDefinesWinner(verifyChoiceUser.ChoiceEnum.ToString(), verifyChoiceCPU.ChoiceEnum.ToString());

                Console.WriteLine(result.ResultMessage);
            }
            Console.ReadKey();
        }
    }
}
