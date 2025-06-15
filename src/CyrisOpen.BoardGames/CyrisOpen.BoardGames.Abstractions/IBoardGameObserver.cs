namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IBoardGameObserver<TBoard, TBoardSetup, TMove>
        where TBoard : IBoard<TBoardSetup, TMove>
        where TBoardSetup : IBoardSetup
    {
        void OnGameStarted(IBoardGame<TBoard, TBoardSetup, TMove> boardGame);
        void OnPlayerTurnStarted(IPlayer player);
        void OnPlayerMoveMade(IPlayer player, MoveOutcome moveOutcome);
        void OnBoardStateChanged(IBoard<TBoardSetup, TMove> board);
        void OnGameEnded(IBoardGame<TBoard, TBoardSetup, TMove> boardGame, BoardGameOutcome outcome)
            ;
    }
}
