namespace CyrisOpen.BoardGames.Abstractions
{
    public record PlayerGameStats
    {
        public required IPlayer Player { get; init; }

        public required string GameName { get; init; }

        public int Wins { get; private set; } = 0;

        public int Losses { get; private set; } = 0;

        public int Draws { get; private set; } = 0;

        public int TotalGames => Wins + Losses + Draws;

        public void UpdateStats(MoveOutcome outcome)
        {
            if (outcome.IsGameOver)
            {
                if (outcome.Winner == Player)
                {
                    Wins++;
                }
                else if (outcome.Winner == null)
                {
                    Draws++;
                }
                else
                {
                    Losses++;
                }
            }
        }
    }
}
