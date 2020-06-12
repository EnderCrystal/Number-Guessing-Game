using System;
using System.Collections.Generic;
using System.Text;

namespace Number_Guessing_Game
{
    public static class RulesMenu
    {
        public static void Display()
        {
            //Rules menu
            LogicalFailsave:

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
        }
    }
}
