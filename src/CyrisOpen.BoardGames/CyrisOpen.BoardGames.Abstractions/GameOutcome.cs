namespace CyrisOpen.BoardGames.Abstractions
{
    public record BoardGameOutcome
    {
        public IPlayer? Winner { get; init; }

        public static implicit operator BoardGameOutcome(MoveOutcome moveOutcome) => new()
        {
            Winner = moveOutcome.Winner
        };
    }
}
