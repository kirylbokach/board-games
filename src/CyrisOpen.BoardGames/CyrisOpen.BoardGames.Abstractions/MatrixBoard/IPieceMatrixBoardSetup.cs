namespace CyrisOpen.BoardGames.Abstractions.MatrixBoard
{
    public interface IPieceMatrixBoardSetup : IBoardSetup
    {
        public MatrixSize Size { get; }
    }
}
