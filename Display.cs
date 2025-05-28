/*
 * Manage the display of the game in the console.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class Display
    {
        /// <summary>
        /// Display the word with guessed letters and underscores for unguessed letters.
        /// </summary>
        /// <param name="word">Word to guess</param>
        /// <param name="guessedLetters">list of letters</param>
        public static void ShowWord(string word, List<char> guessedLetters)
        {
            foreach (char c in word)
                Console.Write(guessedLetters.Contains(c) ? c + " " : "_ ");
        }

        /// <summary>
        /// Display a message when the player lose the game.
        /// </summary>
        /// <param name="word">the word</param>
        public static void DisplayLose(string word)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost! The word was: " + word);
            Console.ResetColor();
        }

        /// <summary>
        /// Display the guessed letter, in red if not in the word, and in green if it is in the word.
        /// </summary>
        /// <param name="word">word to guess</param>
        /// <param name="guessedLetters">guessed letter</param>
        public static void ShowGuessedLetters(string word, List<char> guessedLetters)
        {
            Console.Write("Guessed letters: ");
            foreach (char c in guessedLetters)
            {
                if (word.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c + " ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Display the number of attempts left for the player.
        /// </summary>
        /// <param name="attemptsLeft">Attempts left</param>
        public static void ShowStat(int attemptsLeft)
        {
            Console.WriteLine("Attempts left: " + attemptsLeft);
        }

        /// <summary>
        /// Display an error message in red color.
        /// </summary>
        /// <param name="message">the message</param>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

}
