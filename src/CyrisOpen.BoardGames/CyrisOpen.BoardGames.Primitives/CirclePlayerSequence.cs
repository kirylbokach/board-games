using CyrisOpen.BoardGames.Abstractions;

namespace CyrisOpen.BoardGames.Primitives
{
    public class CirclePlayerSequence : BasePlayerSequence, ICreatablePlayerSequence
    {
        public CirclePlayerSequence(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions = PlayerSequenceRandomizationOptions.None,
            int minPlayers = 2, int maxPlayers = int.MaxValue) : base(players, randomizationOptions, minPlayers, maxPlayers)
        {
        }

        protected override int DetermineNextPlayerIndex(int currentPlayerIndex) => (currentPlayerIndex + 1) % Players.Count;


        public static IPlayerSequence Create(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions = PlayerSequenceRandomizationOptions.None, int minPlayers = 2, int maxPlayers = int.MaxValue)
        {
            return new CirclePlayerSequence(players, randomizationOptions, minPlayers, maxPlayers);
        }
    }
}
