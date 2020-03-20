using GuessingGameRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepository_UI__Real_.UI
{
    class ProgramUI
    {
        private readonly GameRepository _gameRepository = new GameRepository();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number:\n" +
                    "1. Play Game\n" +
                    "2. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void PlayGame()
        {
            GameRepository gameRepository = new GameRepository();
            Animal animal = gameRepository.AddAnimals();

            string userGuessCapital;
            string userGuess;

            int attemptCount = 0;
            int hintCount = 0;

            string animalNameCapital = animal.Name;
            string animalName = animalNameCapital.ToLower();
            string animalLocation = animal.Location;
            string animalSkinType = animal.SkinType;
            string animalTravelType = animal.TravelType;
            string animalHint = animal.Hint;
            char firstLetter = animalNameCapital[0];
            int noMoreHints = 0;


            List<string> _wrongGuess = new List<string>();

            Console.WriteLine("Welcome!  We have randomly selected an animal and it is your job to guess it.");
            Console.WriteLine("At any point in time type 'hint' as your guess and we will show you what hints you have received!\n");

            do
            {
                // Console.WriteLine($"The animal is {firstLetter}.");
                Console.WriteLine("Guess an Animal: \n");
                userGuessCapital = Console.ReadLine();
                userGuess = userGuessCapital.ToLower();

                if (userGuess == animalName)
                {
                    attemptCount += 1;
                    Console.WriteLine($"You're right! The animal is a {animalNameCapital}");
                    Console.WriteLine($"It took you {attemptCount} tries to guess it correctly.\n");
                    Console.WriteLine("Press any key to continue");
                    string playAgain = Console.ReadLine();                   
                }
                else if (_wrongGuess.Contains(userGuess))
                {
                    Console.WriteLine("You already guessed this. Try again.\n");
                }
                else if (userGuess == "hint")
                {
                    if (hintCount == 5)
                    {
                        Console.WriteLine($"Your animal lives in the {animalLocation}, has {animalSkinType}, {animalTravelType}, starts with {firstLetter}, and is {animalHint}.\n");
                    }
                    else if (hintCount == 4)
                    {
                        Console.WriteLine($"Your animal lives in the {animalLocation}, has {animalSkinType}, {animalTravelType}, and starts with {firstLetter}.\n");
                    }
                    else if (hintCount == 3)
                    {
                        Console.WriteLine($"Your animal lives in the {animalLocation}, has {animalSkinType}, and {animalTravelType}.\n");
                    }
                    else if (hintCount == 2)
                    {
                        Console.WriteLine($"Your animal lives in the {animalLocation} and has {animalSkinType}.\n");
                    }
                    else if (hintCount == 1)
                    {
                        Console.WriteLine($"Your animal lives in the {animalLocation}.\n");
                    }
                    else if (hintCount == 0)
                    {
                        Console.WriteLine("You don't have any hints yet.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"That is incorrect.  The animal is not a {userGuessCapital}.  Guess again.\n");
                    attemptCount += 1;
                    _wrongGuess.Add(userGuess);
                    if (attemptCount == 15)
                    {
                        Console.WriteLine($"Alright I can't take it anymore.  The animal is {animalNameCapital}.\n");
                    }
                    else if (attemptCount == 10)
                    {
                        hintCount += 1;
                        Console.WriteLine($"This is getting hard to watch.  Here is some help.  This animal is {animalHint}.\n");
                    }
                    else if (hintCount >= 4)
                    {
                        if (noMoreHints == 0)
                        {
                            Console.WriteLine("Sorry you've gotten all your hints!\n");
                            noMoreHints += 1;
                        }
                    }
                    else
                    { 
                        Console.WriteLine("Enter 1 for a hint or hit any key to continue\n");
                        string answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "1":
                                if (hintCount == 0)
                                {
                                    Console.WriteLine($"This animal lives in the {animalLocation}\n");
                                    hintCount += 1;
                                }
                                else if (hintCount == 1)
                                {
                                    Console.WriteLine($"This animal has {animalSkinType}\n");
                                    hintCount += 1;
                                }
                                else if (hintCount == 2)
                                {
                                    Console.WriteLine($"This animal {animalTravelType}\n");
                                    hintCount += 1;
                                }
                                else if (hintCount == 3)
                                {
                                    Console.WriteLine($"This animals name starts with {firstLetter}\n");
                                    hintCount += 1;
                                }
                                break;
                            default:
                                Console.WriteLine("Good Luck!\n");
                                break;
                        }
                    }
                }
            }
            while (userGuess != animalName);
        }
    }
}

