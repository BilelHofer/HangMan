/*
 * Author : Hofer Bilel
 * Date : 21.05.2025
 * Summary : HangMan is a game where the player has to guess a word by suggesting letters within a certain number of guesses.
 */

namespace HangMan
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.Start();
        }
    }
}
