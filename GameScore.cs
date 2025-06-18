using System.Text.Json.Serialization;

namespace HangMan
{
    /// <summary>
    /// Represents a game score entry for the leaderboard.
    /// </summary>
    public class GameScore
    {
        [JsonPropertyName("word")]
        public string Word { get; set; } = "";

        [JsonPropertyName("timeInSeconds")]
        public double TimeInSeconds { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("won")]
        public bool Won { get; set; }

        [JsonPropertyName("attemptsUsed")]
        public int AttemptsUsed { get; set; }

        /// <summary>
        /// Formatted time string for display purposes.
        /// </summary>
        [JsonIgnore]
        public string FormattedTime
        {
            get
            {
                var timeSpan = TimeSpan.FromSeconds(TimeInSeconds);
                if (timeSpan.TotalMinutes >= 1)
                    return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}m";
                else
                    return $"{timeSpan.Seconds}s";
            }
        }
    }
}