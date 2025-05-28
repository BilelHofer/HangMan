/*
 * List of words for the game
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
   public class WordProvider
    {
        private List<string> words = new List<string> { "elephant", "computer", "umbrella", "bicycle", "mountain", "library", "airplane", "chocolate", "giraffe", "sandwich" };

        public string GetWord()
        {
            Random rnd = new Random();
            return words[rnd.Next(words.Count)];
        }
    }

}
