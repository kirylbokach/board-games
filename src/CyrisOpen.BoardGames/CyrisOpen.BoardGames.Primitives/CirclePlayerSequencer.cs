using CyrisOpen.BoardGames.Abstractions;

namespace CyrisOpen.BoardGames.Primitives
{
    public class CirclePlayerSequencer : IPlayerSequencer
    {
        public int ChooseNextPlayerIndex(int curentPlayerIndex, int playerCount) => (curentPlayerIndex + 1) % playerCount;
    }
}
