﻿namespace HangMan
{
    /// <summary>
    /// Manage the display of the game state.
    /// </summary>
    public static class Display
    {
        // assign each message type its own console row
        private const int RowWord = 0;
        private const int RowGuessedLetters = 2;
        private const int RowStat = 4;
        private const int RowError = 12;
        private const int RowEndMessage = 16;
        private const int RowTime = 17;
        private const int RowDrawing = 6;
        private const int DrawingHeight = 6;

        /// <summary>
        /// Clear a specific region in the console by overwriting it with spaces.
        /// </summary>
        /// <param name="startRow">Starting row</param>
        /// <param name="height">Number of row</param>
        private static void ClearRegion(int startRow, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, startRow + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

        /// <summary>
        /// Clear a specific line in the console by overwriting it with spaces.
        /// </summary>
        /// <param name="row">Row fill with white space</param>
        private static void ClearLine(int row) => ClearRegion(row, 1);

        /// <summary>
        /// Display the word to guess, showing guessed letters and underscores for unguessed letters.
        /// </summary>
        /// <param name="word">Word to guess</param>
        /// <param name="guessedLetters">Guessed letters</param>
        public static void ShowWord(string word, List<char> guessedLetters)
        {
            ClearLine(RowWord);
            Console.SetCursorPosition(0, RowWord);
            foreach (char c in word)
                Console.Write(guessedLetters.Contains(c) ? c + " " : "_ ");
        }

        /// <summary>
        /// Display the guessed letters in green if they are in the word, otherwise in red.
        /// </summary>
        /// <param name="word">Word to guess</param>
        /// <param name="guessedLetters">Guessed letters</param>
        public static void ShowGuessedLetters(string word, List<char> guessedLetters)
        {
            ClearLine(RowGuessedLetters);
            Console.SetCursorPosition(0, RowGuessedLetters);
            Console.Write("Guessed letters: ");
            foreach (char c in guessedLetters)
            {
                Console.ForegroundColor = word.Contains(c)
                    ? ConsoleColor.Green
                    : ConsoleColor.Red;
                Console.Write(c + " ");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Display an error message in red.
        /// </summary>
        public static void ShowStat(int attemptsLeft)
        {
            ClearLine(RowStat);
            Console.SetCursorPosition(0, RowStat);
            Console.WriteLine("Attempts left: " + attemptsLeft);
        }

        public static void DisplayError(string message)
        {
            ClearLine(RowError);
            Console.SetCursorPosition(0, RowError);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Display a message indicating the player has lost.
        /// </summary>
        public static void DisplayLose(string word)
        {
            ClearLine(RowEndMessage);
            Console.SetCursorPosition(0, RowEndMessage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost! The word was: " + word);
            Console.ResetColor();
        }

        /// <summary>
        /// Display a message indicating the player has won.
        /// </summary>
        /// <param name="word">word to guess</param>
        /// <param name="gameTime">Time taken to guess the word</param>
        public static void DisplayWin(string word, TimeSpan gameTime)
        {
            ClearLine(RowEndMessage);
            Console.SetCursorPosition(0, RowEndMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You guessed the word: " + word);
            Console.ResetColor();

            ShowGameTime(gameTime);
        }

        /// <summary>
        /// Draw the hangman figure based on the number of wrong attempts.
        /// </summary>
        /// <param name="wrongCount">Wrong Attempts</param>
        public static void ShowHangman(int wrongCount)
        {
            // 6 attempts to draw the hangman figure
            var lines = new List<string>
            {
                "   +---+",
                "   |   |",
                "   |    ",
                "   |    ",
                "   |    ",
                "  _|_   "
            };

            if (wrongCount >= 1) lines[2] = "   |   O";
            if (wrongCount >= 2) lines[3] = "   |   |";
            if (wrongCount >= 3) lines[3] = "   |  /|";
            if (wrongCount >= 4) lines[3] = "   |  /|\\";
            if (wrongCount >= 5) lines[4] = "   |  / ";
            if (wrongCount >= 6) lines[4] = "   |  / \\";

            // clear the previous hangman drawing
            ClearRegion(RowDrawing, DrawingHeight);

            // display the hangman figure
            for (int i = 0; i < lines.Count; i++)
            {
                Console.SetCursorPosition(0, RowDrawing + i);
                Console.WriteLine(lines[i]);
            }
        }
        /// <summary>
        /// Show the elapsed game time in the console.
        /// </summary>
        /// <param name="gameTime"></param>
        private static void ShowGameTime(TimeSpan gameTime)
        {
            ClearLine(RowTime);
            Console.SetCursorPosition(0, RowTime);
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (gameTime.TotalMinutes >= 1)
            {
                Console.WriteLine($"Time taken: {gameTime.Minutes:D2}:{gameTime.Seconds:D2} minutes");
            }
            else
            {
                Console.WriteLine($"Time taken: {gameTime.Seconds} seconds");
            }

            Console.ResetColor();
        }
    }
}
