namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IPlayerSequencer
    {
        int ChooseNextPlayerIndex(int curentPlayerIndex, int playerCount);
    }
}
