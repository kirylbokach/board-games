namespace CyrisOpen.TicTacToe.Logic.Abstractions
{
    /// <summary>
    /// Generic abstraction for the game board
    /// </summary>
    public interface IBoard<TGameState>
    {
        /// <summary>
        /// Resets board to its initial state
        /// </summary>
        void Reset();

        /// <summary>
        /// Gets or sets the current state of the game
        /// </summary>
        TGameState State { get; set; }
    }
}
