namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IBoardSetup
    {
        public int MinPlayers { get; }

        public int MaxPlayers { get; }

        public int? MaxMoves { get; }
    }
}
