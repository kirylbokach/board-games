namespace CyrisOpen.BoardGames.Abstractions
{
    public abstract class BoardGame<TBoard, TBoardSetup, TMove> where TBoard : IBoard<TBoardSetup, TMove> where TBoardSetup : IBoardSetup
    {
        private readonly IPlayerSequence _playerSequence;
        private readonly TBoard _board;
        private readonly IBoardRenderer<TBoard>? _boardRenderer;

        protected BoardGame(IPlayerSequence playerSequence, TBoard board, IBoardRenderer<TBoard>? boardRenderer = null)
        {
            _playerSequence = playerSequence ?? throw new ArgumentNullException(nameof(playerSequence));
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _boardRenderer = boardRenderer;
        }

        public BoardGameOutcome Play(IEnumerable<IPlayer> players, TBoardSetup boardSetup, PlayerSequenceRandomizationOptions randomizationOptions)
        {
            _board.Initialize(boardSetup);
            _playerSequence.Initialize(players, randomizationOptions, boardSetup.MinPlayers, boardSetup.MaxPlayers);

            BoardGameOutcome gameOutcome;

            _boardRenderer?.Render(_board);

            do
            {
                var moveOutcome = MakePlayerMove(_playerSequence.Current, _board, _playerSequence.Players);

                _boardRenderer?.Render(_board);

                if (moveOutcome.IsGameOver) 
                {
                    gameOutcome = moveOutcome;
                    break;
                }

                _playerSequence.Advance();
            } while (true);

            foreach (var player in _playerSequence.Players)
            {
                player.AnalyzeGameOutcome(_board);
            }

            return gameOutcome;
        }

        private static MoveOutcome MakePlayerMove(IPlayer player, TBoard board, IEnumerable<IPlayer> players)
        {
            var move = player.PlayTurn(board);

            var outcome = board.AcceptMove(player, move);

            while (outcome.Status == MoveStatus.Rejected)
            {
                move = player.ReplayMove(board, move, outcome);
                outcome = board.AcceptMove(player, move);
            }

            foreach (var p in players)
                p.AnalyzeMoveOutcome(player, board, move, outcome);

            return outcome;
        }
    }
}
