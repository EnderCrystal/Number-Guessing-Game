using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Number_Guessing_Game
{
    internal class Program
    {
        static void StartGame(int max)
        {
            Console.WriteLine("\r\nYou have selected the easy difficulty. The numbers generated are going to range from 0 to 50. Do you wish to proceed?\r\n");

        EasySelectionFailSave:

            Console.WriteLine("Please answer: \"yes\", to proceed, or \"no\" to go back to the difficulty selection menu.\r\n");
            string answereasy = Console.ReadLine();

            if (string.Compare(answereasy, "no", true) == 0)
            {
                return;
            }
            else if (string.Compare(answereasy, "yes", true) != 0)
            {
                Console.WriteLine("This is not a valid answer, please answer as instructed.");
                goto EasySelectionFailSave;
            }

            //Test comment delete later

        EasySelection:

            //Number Rolling; Resetting UI intigers

            int numberOfTries;
            numberOfTries = 0;

            Random rnd = new Random();
            int randomNumberEasy = rnd.Next(51);
            Console.WriteLine("{0,-20} {1,40}", "\r\nThe number has been generated! Please type in your guess! You have 20 tries!", "Tries: " + numberOfTries);

        //Console.WriteLine("{1,40}", "Time: " + currentTime);        Add a basic timer later on
        //Add a "guessed" number list, that sorts them from smallest to largest

        NumberGuessEasy:

            //Fail Condition

            if (numberOfTries > 19)
            {
            FailCondition:
                Console.WriteLine("You failed! Would you like to try again? [yes/no]");
                string tryagainfail = Console.ReadLine();
                if (string.Compare(answereasy, "yes", true) == 0)
                {
                    goto EasySelection;
                }
                else if (string.Compare(answereasy, "no", true) == 0)
                {
                    Console.WriteLine("Thank you for playing!");
                }
                else
                {
                    Console.WriteLine("That is not a valid answer. Please answer as instructed.");
                    goto FailCondition;
                }
            }

            //Catching guessed numbers; Written prompt responces

            var gsdNmbrAsStr = Console.ReadLine();
            int guessedNumber;

            while (!int.TryParse(gsdNmbrAsStr, out guessedNumber))
            {
                Console.WriteLine("\r\nThis input is invalid. Please only use full numbers when trying again.\r\n");
                goto NumberGuessEasy;
            }
            if (randomNumberEasy == guessedNumber)
            {
                numberOfTries = numberOfTries + 1;
                Console.WriteLine("{0,-20} {1,98}", "\r\nYou have guessed the number! Congratulations!" +
                    " \r\nThe number was: " + randomNumberEasy, "Tries: " + numberOfTries);
                return;
            }
            else if (randomNumberEasy > guessedNumber)
            {
                numberOfTries = numberOfTries + 1;
                Console.WriteLine("{0,-20} {1,76}", "\r\nThe number you're looking for is higher!", "Tries: " + numberOfTries);
                goto NumberGuessEasy;
            }
            else if (randomNumberEasy < guessedNumber)
            {
                numberOfTries = numberOfTries + 1;
                Console.WriteLine("{0,-20} {1,76}", "\r\nThe number you're looking for is lower !", "Tries: " + numberOfTries);
                goto NumberGuessEasy;
            }
        }
        
        static void Main()
        {
        //The Hard and Impossible difficulties can't be selected as they end the code for some reason
        //Implement a timer
        //Implement a sorted, and unsorted list of already imputed numbers
        
        //Beginning lines

        LogicalFailsave:
            Console.WriteLine("Welcome to the Number Guessing Game!");

            //Rules menu

            Console.WriteLine("\r\nWould you like to learn the rules first?");
            Console.WriteLine("yes/no ? \r\n");

            string rulesprompt = Console.ReadLine();

            if (string.Compare(rulesprompt, "yes", true) == 0)
            {
                Console.WriteLine("\r\nThe rules of the game are very simple. The program will generate a random number, " +
                    "size of which \r\nwill depend on your chosen difficulty setting. Once the number is generated, write your guessed number, \r\nand the program" +
                    " will tell you whether your guess was larger, or smaller than the generated number. \r\nYou win once you guess the generated number. " +
                    "The program will also track the number of your guesses, \r\nand the time it took you to guess the answer. With this out of the way, have fun!");
            }
            else if (string.Compare(rulesprompt, "no", true) == 0)
            {
                Console.WriteLine("\r\nOkay! Have fun!");
            }
            else
            {
                Console.WriteLine("That... that's not the answer I expected. \r\nI'll assume you either misspelled a two / three letter word, \r\nor you just want" +
                    " to play a *jokus* on me. Either way, I'm not dealing with this nonsense. \r\n");
                goto LogicalFailsave;
            }

        // Difficulty Choosing Menu

        DifficultyMenuFailsave:

            Console.WriteLine("\r\nPlease select the difficulty by typing in \"easy\", \"medium\" or \"hard\"!\r\n");

            string difficulty = Console.ReadLine();

            //
            // Easy Difficulty
            //

            if (string.Compare(difficulty, "easy", true) == 0)
            {
                StartGame(50);

            playAgainScript:

                Console.WriteLine("Would you like to continue playing? [yes/no]");
                string playAgainScript = Console.ReadLine();
                if (string.Compare(playAgainScript, "yes", true) == 0)
                {
                    goto DifficultyMenuFailsave;
                }
                else if (string.Compare(playAgainScript, "no", true) == 0)
                {
                    Console.WriteLine("\r\nThanks for playing!!\r\n");
                }
                else
                {
                    Console.WriteLine("That is not a valid answer! Please answer as instructed.");
                    goto playAgainScript;
                }
            }
        }
    }
}
