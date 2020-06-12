using System;
using System.Collections.Generic;
using System.Text;

namespace Number_Guessing_Game
{
    public static class Game
    {
        public static void StartGame(int max, string difficultyName)
        {
            Console.WriteLine($"\r\nYou have selected the {difficultyName} difficulty. The numbers generated are going to range from 0 to {max}. Do you wish to proceed?\r\n");

        SelectionFailSave:

            Console.WriteLine("Please answer: \"yes\", to proceed, or \"no\" to go back to the difficulty selection menu.\r\n");
            string answer = Console.ReadLine();

            if (string.Compare(answer, "no", true) == 0)
            {
                return;
            }
            else if (string.Compare(answer, "yes", true) != 0)
            {
                Console.WriteLine("This is not a valid answer, please answer as instructed.");
                goto SelectionFailSave;
            }

        Selection:

            //Number Rolling; Resetting UI intigers

            int numberOfTries;
            numberOfTries = 0;

            Random rnd = new Random();
            int randomNumberEasy = rnd.Next(max + 1);
            Console.WriteLine("{0,-20} {1,40}", "\r\nThe number has been generated! Please type in your guess! You have 20 tries!", "Tries: " + numberOfTries);

        //Console.WriteLine("{1,40}", "Time: " + currentTime);        Add a basic timer later on
        //Add a "guessed" number list, that sorts them from smallest to largest

        NumberGuess:

            //Fail Condition

            if (numberOfTries > 19)
            {
            FailCondition:
                Console.WriteLine("You failed! Would you like to try again? [yes/no]");
                string tryagainfail = Console.ReadLine();
                if (string.Compare(answer, "yes", true) == 0)
                {
                    goto Selection;
                }
                else if (string.Compare(answer, "no", true) == 0)
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
                goto NumberGuess;
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
                goto NumberGuess;
            }
            else if (randomNumberEasy < guessedNumber)
            {
                numberOfTries = numberOfTries + 1;
                Console.WriteLine("{0,-20} {1,76}", "\r\nThe number you're looking for is lower !", "Tries: " + numberOfTries);
                goto NumberGuess;
            }
        }

    }
}
