namespace CyrisOpen.BoardGames.Abstractions
{
    public abstract class BoardGame<TBoard, TBoardSetup, TMove> : IBoardGame<TBoard, TBoardSetup, TMove> 
        where TBoard : IBoard<TBoardSetup, TMove> 
        where TBoardSetup : IBoardSetup
    {
        private readonly IPlayerSequence _playerSequence;
        private readonly TBoard _board;
        private readonly List<IBoardGameObserver<TBoard, TBoardSetup, TMove>> _boardGameObservers = [];

        public abstract string Name { get; }
        
        public IEnumerable<IPlayer> Players => _playerSequence.Players;

        public TBoard Board => _board;

        protected BoardGame(IPlayerSequence playerSequence, TBoard board)
        {
            _playerSequence = playerSequence ?? throw new ArgumentNullException(nameof(playerSequence));
            _board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public BoardGameOutcome Play(IEnumerable<IPlayer> players, TBoardSetup boardSetup, PlayerSequenceRandomizationOptions randomizationOptions)
        {
            _board.Initialize(boardSetup);
            _playerSequence.Initialize(players, randomizationOptions, boardSetup.MinPlayers, boardSetup.MaxPlayers);

            BoardGameOutcome gameOutcome;

            _boardGameObservers.ForEach(observer => observer.OnGameStarted(this));
            _boardGameObservers.ForEach(observer => observer.OnBoardStateChanged(_board));

            do
            {
                var moveOutcome = MakePlayerMove(_playerSequence.Current);

                _boardGameObservers.ForEach(observer => observer.OnBoardStateChanged(_board));

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

            _boardGameObservers.ForEach(observer => observer.OnGameEnded(this, gameOutcome));

            return gameOutcome;
        }

        private MoveOutcome MakePlayerMove(IPlayer player)
        {
            _boardGameObservers.ForEach(observer => observer.OnPlayerTurnStarted(player));

            var move = player.PlayTurn(_board);

            var outcome = _board.AcceptMove(player, move);

            _boardGameObservers.ForEach(observer => observer.OnPlayerMoveMade(player, outcome));

            while (outcome.Status == MoveStatus.Rejected)
            {
                move = player.ReplayMove(_board, move, outcome);
                outcome = _board.AcceptMove(player, move);
                _boardGameObservers.ForEach(observer => observer.OnPlayerMoveMade(player, outcome));
            }

            foreach (var p in Players)
                p.AnalyzeMoveOutcome(player, _board, move, outcome);

            return outcome;
        }

        public void AddObserver(IBoardGameObserver<TBoard, TBoardSetup, TMove> observer)
        {
            ArgumentNullException.ThrowIfNull(observer, nameof(observer));

            _boardGameObservers.Add(observer);
        }

        public void RemoveObserver(IBoardGameObserver<TBoard, TBoardSetup, TMove> observer)
        {
            ArgumentNullException.ThrowIfNull(observer, nameof(observer));

            _boardGameObservers.Remove(observer);
        }
    }
}
