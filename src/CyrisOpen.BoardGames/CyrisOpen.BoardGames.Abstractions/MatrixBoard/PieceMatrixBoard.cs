namespace CyrisOpen.BoardGames.Abstractions.MatrixBoard
{
    public abstract class PieceMatrixBoard<TBoardSetup, TMove, TPlayerPiece> : IBoard<TBoardSetup, TMove> 
        where TBoardSetup : IPieceMatrixBoardSetup
        where TPlayerPiece : IPlayerPiece
        where TMove : notnull
    {
        public bool IsGameOver { get; protected set; }
        public IPlayer? Winner { get; protected set; }
        public TBoardSetup? Setup { get; private set; }

        protected bool IsBoardFull => MutableMovesMade.Count >= Setup?.MaxMoves;

        public IReadOnlyCollection<(IPlayer Player, TMove Move)> MovesMade => MutableMovesMade.AsReadOnly();

        public MoveOutcome AcceptMove(IPlayer player, TMove move)
        {
            // Throw rather than reject a move to prevent possible perpettual loop in the game logic
            if (IsGameOver) throw new InvalidOperationException("Cannot accept a move when the game is already over.");

            var outcome = EvaluateMove(player, move);

            if (outcome.Status == MoveStatus.Accepted)
            {
                MutableMovesMade.Add((player, move));

                if (IsBoardFull)
                {
                    outcome = outcome with { IsGameOver = true };
                }

                if (outcome.IsGameOver)
                {
                    IsGameOver = true;
                    Winner = outcome.Winner;
                }
            }

            return outcome;
        }

        protected abstract MoveOutcome EvaluateMove(IPlayer player, TMove move);

        public virtual void Initialize(TBoardSetup setup)
        {
            ArgumentNullException.ThrowIfNull(setup, nameof(setup));
            Setup = setup;
            MutableMatrix = [.. Enumerable.Range(0, setup.Size.Rows).Select(row => new List<TPlayerPiece?>(new TPlayerPiece?[setup.Size.Columns]))];
            MutableMovesMade.Clear();
        }
            
        public IReadOnlyCollection<IReadOnlyCollection<IPlayerPiece?>>? Matrix =>
            MutableMatrix?.ConvertAll(row => (IReadOnlyCollection<IPlayerPiece?>)row.AsReadOnly());

        protected List<List<TPlayerPiece?>>? MutableMatrix { get; private set; }

        protected List<(IPlayer Player, TMove Move)> MutableMovesMade { get; } = [];
    }
}
