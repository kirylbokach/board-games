namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IBoard<TBoardSetup, TMove>
    {
        MoveOutcome AcceptMove(IPlayer player, TMove move);

        void UndoLastMove();

        bool IsGameOver { get; }
        IPlayer? Winner { get; }

        TBoardSetup Setup { get; }

        void Initialize(TBoardSetup setup);

        IReadOnlyCollection<(IPlayer Player, TMove Move)> MovesMade { get; }
    }
}
