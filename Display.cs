/*
* Manage the display of the game in the console.
* 
*/

namespace HangMan
{
    public static class Display
    {
        // assign each message type its own console row
        private const int ROW_WORD = 0;
        private const int ROW_GUESSED_LETTERS = 2;
        private const int ROW_STAT = 4;
        private const int ROW_ERROR = 6;
        private const int ROW_END_MESSAGE = 8;

        // helper to clear a single console line at the given row
        private static void ClearLine(int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, row);
        }

        /// <summary>
        /// Display the word with guessed letters and underscores for unguessed letters
        /// in its fixed region.
        /// </summary>
        public static void ShowWord(string word, List<char> guessedLetters)
        {
            ClearLine(ROW_WORD);
            Console.SetCursorPosition(0, ROW_WORD);

            foreach (char c in word)
                Console.Write(guessedLetters.Contains(c) ? c + " " : "_ ");
        }

        /// <summary>
        /// Display the guessed letters, in green if correct and red if not.
        /// </summary>
        public static void ShowGuessedLetters(string word, List<char> guessedLetters)
        {
            ClearLine(ROW_GUESSED_LETTERS);
            Console.SetCursorPosition(0, ROW_GUESSED_LETTERS);

            Console.Write("Guessed letters: ");
            foreach (char c in guessedLetters)
            {
                if (word.Contains(c))
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(c + " ");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Display the number of attempts left.
        /// </summary>
        public static void ShowStat(int attemptsLeft)
        {
            ClearLine(ROW_STAT);
            Console.SetCursorPosition(0, ROW_STAT);
            Console.WriteLine("Attempts left: " + attemptsLeft);
        }

        /// <summary>
        /// Display an error message in red in its own region.
        /// </summary>
        public static void DisplayError(string message)
        {
            ClearLine(ROW_ERROR);
            Console.SetCursorPosition(0, ROW_ERROR);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Display the lose message in its own region.
        /// </summary>
        public static void DisplayLose(string word)
        {
            ClearLine(ROW_END_MESSAGE);
            Console.SetCursorPosition(0, ROW_END_MESSAGE);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost! The word was: " + word);
            Console.ResetColor();
        }
    }
}
