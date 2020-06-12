using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Number_Guessing_Game
{
    internal class Program
    {
       
        static void Main()
        {
            //The Hard and Impossible difficulties can't be selected as they end the code for some reason
            //Implement a timer
            //Implement a sorted, and unsorted list of already imputed numbers

            //Beginning lines

            Console.WriteLine("Welcome to the Number Guessing Game!");
            RulesMenu.Display();

        // Difficulty Choosing Menu

        DifficultyMenuFailsave:

            Console.WriteLine("\r\nPlease select the difficulty by typing in \"easy\", \"medium\" or \"hard\"!\r\n");

            string difficulty = Console.ReadLine();

            if (string.Compare(difficulty, "easy", true) == 0)
            {
                Game.StartGame(50, "easy");
            }
            else if (string.Compare(difficulty, "medium", true) == 0)
            {
                Game.StartGame(200, "medium");
            }

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
