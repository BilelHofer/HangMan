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
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. View Leaderboard");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Choose an option (1-3): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        ViewLeaderboard();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey(true);
                        break;
                }
            } while (true);
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

        /// <summary>
        /// Starts the game.
        /// </summary>
        private static void StartGame()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Press any key to start the game...");
                Console.ReadKey(true);

                GameManager game = new GameManager();
                game.Start();
            } while (AskToPlayAgain());
        }

        /// <summary>
        /// Shows the leaderboard.
        /// </summary>
        private static void ViewLeaderboard()
        {
            LeaderboardManager leaderboard = new LeaderboardManager();
            leaderboard.DisplayLeaderboard();
        }
    }
}
