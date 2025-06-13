namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IBoardRenderer<in TBoard>
    {
        void Render(TBoard board); 
    }
}
