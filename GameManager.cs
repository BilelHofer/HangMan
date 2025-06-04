namespace HangMan
{
    /// <summary>
    /// Manages the game logic for the game.
    /// </summary>
    public class GameManager
    {
        private string wordToGuess = "";
        private List<char> guessedLetters = new List<char>();
        private const int MAX_ATTEMPTS = 6;
        private int attemptsLeft;
        private WordProvider wordProvider = new WordProvider();

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            wordToGuess = wordProvider.GetWord().ToUpper();

            if (string.IsNullOrEmpty(wordToGuess))
            {
                Console.WriteLine("Error : No word finded !");
                return;
            }


            attemptsLeft = MAX_ATTEMPTS;
            string errorMessage = "";
            bool gameWon = false;

            do
            {
                DisplayGameState(errorMessage);
                errorMessage = "";

                Console.SetCursorPosition(0, 13);
                Console.Write("Which letter do you want to guess? ");
                string? input = Console.ReadLine();

                // Validate and process input
                errorMessage = ProcessInput(input, ref gameWon);
            } while (attemptsLeft > 0 && !gameWon);

            // Display final state and result
            DisplayGameState("");

            if (gameWon)
            {
                Display.DisplayWin(wordToGuess);
            }
            else
            {
                Display.DisplayLose(wordToGuess);
            }
        }

        /// <summary>
        /// Displays the current game state.
        /// </summary>
        private void DisplayGameState(string errorMessage)
        {
            Console.Clear();
            Display.ShowWord(wordToGuess, guessedLetters);
            Display.ShowGuessedLetters(wordToGuess, guessedLetters);
            Display.ShowStat(attemptsLeft);
            Display.ShowHangman(MAX_ATTEMPTS - attemptsLeft);
            Display.DisplayError(errorMessage);
        }

        /// <summary>
        /// Processes the user input and returns any error message.
        /// </summary>
        private string ProcessInput(string? input, ref bool gameWon)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                return "Invalid input. Please enter a valid letter.";
            }

            char letter = char.ToUpper(input[0]);

            if (guessedLetters.Contains(letter))
            {
                return "You have already guessed this letter.";
            }

            guessedLetters.Add(letter);

            if (!wordToGuess.Contains(letter))
            {
                attemptsLeft--;
            }
            else
            {
                gameWon = CheckIfWon();
            }

            return "";
        }

        /// <summary>
        /// Checks if all letters have been guessed.
        /// </summary>
        private bool CheckIfWon()
        {
            foreach (char letter in wordToGuess)
            {
                if (!guessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}