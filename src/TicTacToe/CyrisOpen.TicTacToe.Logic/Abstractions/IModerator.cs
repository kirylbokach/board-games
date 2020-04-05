using System.Collections.Generic;

namespace CyrisOpen.TicTacToe.Logic.Abstractions
{
    /// <summary>
    /// Generic game moderator
    /// </summary>
    public interface IModerator<TGameState>
    {
        /// <summary>
        /// Plays a single game with a given number of players and board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="players"></param>
        void Play(IBoard<TGameState> board, IEnumerable<IPlayer<TGameState>> players);
    }
}
