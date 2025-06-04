using System;
using System.Collections.Generic;
using System.IO;

namespace HangMan
{
    /// <summary>
    /// Provides a random word from a file containing a list of words for the Hangman game.
    /// </summary>
    public class WordProvider
    {
        private List<string> words = new List<string>();
        private readonly string filePath;

        /// <summary>
        /// Initializes the WordProvider with a path to the words file.
        /// </summary>
        /// <param name="filePath">The path to the file containing words.</param>
        public WordProvider(string filePath = "words.txt")
        {
            this.filePath = Path.Combine(AppContext.BaseDirectory, filePath);
            LoadWords();
        }

        /// <summary>
        /// Loads words from the file into the list.
        /// </summary>
        private void LoadWords()
        {
            if (File.Exists(filePath))
            {
                words = new List<string>(File.ReadAllLines(filePath));

                // Remove empty lines or whitespace
                words.RemoveAll(word => string.IsNullOrWhiteSpace(word));
            }
        }

        /// <summary>
        /// Returns a random word from the list of words.
        /// </summary>
        /// <returns>The randomly selected word.</returns>
        public string GetWord()
        {
            string word = "";

            if (words.Count > 0)
            {
                Random rnd = new Random();
                word = words[rnd.Next(words.Count)].Trim();
            }

            return word;
        }
    }
}
