using System.Text.Json;

namespace HangMan
{
    /// <summary>
    /// Manages the game leaderboard with JSON persistence.
    /// </summary>
    public class LeaderboardManager
    {
        private readonly string filePath;
        private List<GameScore> scores = new List<GameScore>();

        public LeaderboardManager(string filePath = "leaderboard.json")
        {
            this.filePath = Path.Combine(AppContext.BaseDirectory, filePath);
            LoadScores();
        }

        /// <summary>
        /// Loads scores from the JSON file.
        /// </summary>
        private void LoadScores()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        var loadedScores = JsonSerializer.Deserialize<List<GameScore>>(json);
                        scores = loadedScores ?? new List<GameScore>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading leaderboard: {ex.Message}");
                    scores = new List<GameScore>();
                }
            }
        }

        /// <summary>
        /// Saves scores to the JSON file.
        /// </summary>
        private void SaveScores()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(scores, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving leaderboard: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new score to the leaderboard.
        /// </summary>
        public void AddScore(GameScore score)
        {
            scores.Add(score);
            SaveScores();
        }

        /// <summary>
        /// Gets the top scores, sorted by time (fastest first) for won games only.
        /// </summary>
        public List<GameScore> GetTopScores(int count = 10)
        {
            return scores
                .Where(s => s.Won)
                .OrderBy(s => s.TimeInSeconds)
                .Take(count)
                .ToList();
        }

        /// <summary>
        /// Displays the leaderboard in the console.
        /// </summary>
        public void DisplayLeaderboard()
        {
            var topScores = GetTopScores();

            Console.Clear();
            Console.WriteLine("LEADERBOARD - TOP 10");
            Console.WriteLine(new string('=', 40));

            if (topScores.Count == 0)
            {
                Console.WriteLine("No scores yet.");
            }
            else
            {
                Console.WriteLine("Rank | Word        | Time     | Date");
                Console.WriteLine(new string('-', 40));

                for (int i = 0; i < topScores.Count; i++)
                {
                    var score = topScores[i];
                    Console.WriteLine($"{i + 1, 4} | {score.Word, -11} | {score.FormattedTime, -8} | {score.Date:MM/dd/yy}");
                }
            }

            Console.WriteLine(new string('=', 40));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}