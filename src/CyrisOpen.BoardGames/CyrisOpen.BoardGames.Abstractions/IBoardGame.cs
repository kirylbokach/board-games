namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IBoardGame<TBoard, TBoardSetup, TMove>
        where TBoard : IBoard<TBoardSetup, TMove>
        where TBoardSetup : IBoardSetup
    {
        string Name { get; }

        IEnumerable<IPlayer> Players { get; }

        TBoard Board { get; }

        BoardGameOutcome Play(IEnumerable<IPlayer> players, TBoardSetup boardSetup, PlayerSequenceRandomizationOptions randomizationOptions);

        void AddObserver(IBoardGameObserver<TBoard, TBoardSetup, TMove> observer);

        void RemoveObserver(IBoardGameObserver<TBoard, TBoardSetup, TMove> observer);
    }
}
