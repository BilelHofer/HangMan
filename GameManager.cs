/*
 * GameCore
 * 
 */

namespace HangMan
{
    public class GameManager
    {
        private string wordToGuess = "";
        private List<char> guessedLetters = new List<char>();
        private const int MAX_ATTEMPTS = 6;
        private int attemptsLeft;
        private WordProvider wordProvider = new WordProvider();

        /// <summary>
        /// Starts the game
        /// </summary>
        public void Start()
        {
            wordToGuess = wordProvider.GetWord().ToUpper();
            attemptsLeft = MAX_ATTEMPTS;
            string errorMessage = "";

            while (attemptsLeft > 0)
            {
                Console.Clear();
                Display.ShowWord(wordToGuess, guessedLetters);
                Display.ShowGuessedLetters(wordToGuess, guessedLetters);
                Display.ShowStat(attemptsLeft);
                Display.ShowHangman(MAX_ATTEMPTS - attemptsLeft);
                Display.DisplayError(errorMessage);
                errorMessage = "";

                Console.SetCursorPosition(0, 13);
                Console.Write("Which letter do you want to guess? ");


                string? input = Console.ReadLine();

                // Check if the input is null
                if (string.IsNullOrEmpty(input))
                {
                    errorMessage = "Invalid input. Please enter a valid letter.";
                    continue;
                }

                // Check if the letter is valid
                if (input.Length != 1 || !char.IsLetter(input[0]))
                {
                    errorMessage = "Invalid input. Please enter a valid letter.";
                    continue;
                }

                char letter = char.ToUpper(input[0]);

                // Check if the letter is already guessed
                if (guessedLetters.Contains(letter))
                {
                    errorMessage = "You have already guessed this letter.";
                    continue;
                }

                guessedLetters.Add(letter);

                // Check if the letter is in the word
                if (!wordToGuess.Contains(letter))
                {
                    attemptsLeft--;
                }
            }

            Display.ShowHangman(MAX_ATTEMPTS - attemptsLeft);
            // Game over
            Display.DisplayLose(wordToGuess);
        }
    }
}
