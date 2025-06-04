/*
 * Author : Hofer Bilel
 * Date : 21.05.2025
 * Summary : HangMan is a game where the player has to guess a word by suggesting letters within a certain number of guesses.
 */

namespace HangMan
{
    /// <summary>
    /// Main entry point for the game.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Initialize and start the game manager
            Console.Title = "HangMan Game";

            do { 
            Console.Clear();
            Console.WriteLine("Welcome to HangMan!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true); // Wait for user input to start the game

                GameManager game = new GameManager();
            game.Start();
            } while (AskToPlayAgain());
        }

        /// <summary>
        /// Asks the player if they want to play again.
        /// </summary>
        /// <returns>True if the user press y or yes</returns>
        private static bool AskToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string? input = Console.ReadLine()?.ToLower();
            return input == "y" || input == "yes";
        }
    }
}
