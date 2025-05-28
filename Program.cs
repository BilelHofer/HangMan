/*
 * Author : Hofer Bilel
 * Date : 21.05.2025
 * Summary : HangMan is a game where the player has to guess a word by suggesting letters within a certain number of guesses.
 */


namespace HangMan
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Start the game
            GameManager gameManager = new GameManager();

            bool isPlaying = true;

            do
            {
                Console.Write("Which letter do you want to guess? ");

                string letter = Console.ReadLine();

                // Check if the letter is valid
                if (letter.Length != 1 || !char.IsLetter(letter[0]))
                {
                    DisplayError("Invalid input. Please enter a valid letter.");
                    continue;
                }

                // Check if the letter is already guessed
                if (gameManager.GuessedLetters.Contains(letter.ToUpper()))
                {
                    DisplayError("You have already guessed this letter.");
                    continue;
                }

                                

            } while (isPlaying);
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
