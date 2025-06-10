namespace CyrisOpen.BoardGames.Abstractions
{
    /// <summary>
    /// Abstraction for a sequence of players in a game with functionality to advance the current player.
    /// </summary>
    public interface IPlayerSequence
    {
        /// <summary>
        /// Gets the currently active player in the game.
        /// </summary>
        IPlayer Current { get; }

        /// <summary>
        /// Advances the current player to the next player.
        /// </summary>
        /// <returns>Currently active  player</returns>
        IPlayer Advance();

        /// <summary>
        /// The collection of all players in the sequence.
        /// </summary>
        IReadOnlyCollection<IPlayer> Players { get; }

        void Initialize(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions = 0,
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
