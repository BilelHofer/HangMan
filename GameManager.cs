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
            bool gameWon = false;

            do
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

                // Process input only if valid
                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Length == 1 && char.IsLetter(input[0]))
                    {
                        char letter = char.ToUpper(input[0]);

                        if (!guessedLetters.Contains(letter))
                        {
                            guessedLetters.Add(letter);

                            // Check if the letter is in the word
                            if (!wordToGuess.Contains(letter))
                            {
                                attemptsLeft--;
                            }
                            else
                            {
                                // Check if the player has won
                                bool allLettersGuessed = true;
                                foreach (char c in wordToGuess)
                                {
                                    if (!guessedLetters.Contains(c))
                                    {
                                        allLettersGuessed = false;
                                        break;
                                    }
                                }
                                gameWon = allLettersGuessed;
                            }
                        }
                        else
                        {
                            errorMessage = "You have already guessed this letter.";
                        }
                    }
                    else
                    {
                        errorMessage = "Invalid input. Please enter a valid letter.";
                    }
                }
                else
                {
                    errorMessage = "Invalid input. Please enter a valid letter.";
                }
            } while (attemptsLeft > 0 && !gameWon);

            // Display final state
            Console.Clear();
            Display.ShowWord(wordToGuess, guessedLetters);
            Display.ShowGuessedLetters(wordToGuess, guessedLetters);
            Display.ShowStat(attemptsLeft);
            Display.ShowHangman(MAX_ATTEMPTS - attemptsLeft);

            // Game over
            if (gameWon)
            {
                Display.DisplayWin(wordToGuess);
            }
            else
            {
                Display.DisplayLose(wordToGuess);
            }
        }
    }
}