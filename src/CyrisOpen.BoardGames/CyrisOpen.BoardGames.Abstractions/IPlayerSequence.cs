namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IPlayerSequence
    {
        IPlayer Next { get; }
    }

    public interface ICreatablePlayerSequence : IPlayerSequence
    {
        static abstract IPlayerSequence Create(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions = 0,
            int minPlayers = 2, int maxPlayers = int.MaxValue);
    }

    [Flags]
    public enum PlayerSequenceRandomizationOptions
    {
        None = 0,
        RandomizeFirstMove = 1,
        RandomizeOrder = 2
    }
}
