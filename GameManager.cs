using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class GameManager
    {
        private List<string> guessedLetters = new List<string>();

        public List<string> GuessedLetters { get => guessedLetters; set => guessedLetters = value; }
    }
}
