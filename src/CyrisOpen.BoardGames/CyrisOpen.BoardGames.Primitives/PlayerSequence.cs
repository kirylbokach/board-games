using CyrisOpen.BoardGames.Abstractions;

namespace CyrisOpen.BoardGames.Primitives
{
    public class PlayerSequence : IPlayerSequence
    {
        private List<IPlayer> _players = [];

        private int _currentPlayerIndex = 0;
        private readonly IPlayerSequencer _playerSequencer;
        private readonly IRandomizer _randomizer;

        protected PlayerSequence(IPlayerSequencer sequencer, IRandomizer randomizer)
        {
            _playerSequencer = sequencer ?? throw new ArgumentNullException(nameof(sequencer), "Player sequencer cannot be null.");
            _randomizer = randomizer ?? throw new ArgumentNullException(nameof(randomizer), "Randomizer cannot be null.");
        }

        public IPlayer Current
        {
            get
            {
                if (_players.Count == 0) throw new InvalidOperationException("Players sequence has not been initialized.");

                return _players[_currentPlayerIndex];
            }
        }

        private void AssertValidPlayerIndex(int index)
        {
            if (index < 0 || index >= _players.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Player index is out of range.");
            }
        }

        IReadOnlyCollection<IPlayer> IPlayerSequence.Players => _players.AsReadOnly();

        public IPlayer Advance()
        {
            _currentPlayerIndex = _playerSequencer.ChooseNextPlayerIndex(_currentPlayerIndex, _players.Count);
            AssertValidPlayerIndex(_currentPlayerIndex);
            return Current;
        }

        public void Initialize(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions = PlayerSequenceRandomizationOptions.None, int minPlayers = 2, int maxPlayers = int.MaxValue)
        {
            ArgumentNullException.ThrowIfNull(players, nameof(players));

            if ((randomizationOptions & PlayerSequenceRandomizationOptions.RandomizeOrder) != 0)
            {
                _players = [.. players.OrderBy(_ => _randomizer.Next())];
            }
            else
            {
                _players = [.. players];
            }

            if (!_players.Any()) throw new ArgumentException("Players collection cannot be empty.", nameof(players));

            ArgumentOutOfRangeException.ThrowIfLessThan(_players.Count, minPlayers, nameof(players));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(_players.Count, maxPlayers, nameof(players));

            if ((randomizationOptions & PlayerSequenceRandomizationOptions.RandomizeFirstMove) != 0)
            {
                _currentPlayerIndex = _randomizer.Next(0, _players.Count);
            }
        }
    }
}
