using System;
using GuessingGameRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GuessingGameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void AddAnimalTest()
        {
            GameRepository gameRepository = new GameRepository();
            Animal animal = gameRepository.AddAnimals();
            Console.WriteLine("Your animal is: " + animal);
        }
    }
}
