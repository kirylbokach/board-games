namespace CyrisOpen.TicTacToe.Logic.Abstractions
{
    /// <summary>
    /// Generic abstraction for a board game player
    /// </summary>
    public interface IPlayer<TGameState>
    {
        /// <summary>
        /// Makes a move for given state of the board
        /// </summary>
        TGameState MakeMove(TGameState boardState);

        /// <summary>
        /// Analyzes the outcome of a finished game
        /// </summary>
        void AnalyzeOutcome(TGameState boardState);
    }
}
