namespace CyrisOpen.BoardGames.Abstractions
{
    public record MoveOutcome
    {
        public MoveStatus Status { get; init; }
        public string? RejectionReason { get; init; }
        public bool IsGameOver { get; init; }
        public IPlayer? Winner { get; init; }

        public static MoveOutcome Accepted() => new MoveOutcome { Status = MoveStatus.Accepted };

        public static MoveOutcome Rejected(string reason) => new MoveOutcome { Status = MoveStatus.Rejected, RejectionReason = reason };

        public static MoveOutcome PlayerWins(IPlayer winner) => new MoveOutcome { Status = MoveStatus.Accepted, IsGameOver = true, Winner = winner };

        public static MoveOutcome Draw() => new MoveOutcome { Status = MoveStatus.Accepted, IsGameOver = true };
    }

    public enum MoveStatus
    {
        Accepted,
        Rejected
    }
}
