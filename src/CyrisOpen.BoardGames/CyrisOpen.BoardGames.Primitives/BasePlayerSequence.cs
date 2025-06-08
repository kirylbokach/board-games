using CyrisOpen.BoardGames.Abstractions;

namespace CyrisOpen.BoardGames.Primitives
{
    public abstract class BasePlayerSequence : IPlayerSequence
    {
        private readonly List<IPlayer> _players;

        private int CurrentPlayerIndex { get; set; } = -1;

        protected ICollection<IPlayer> Players => _players.AsReadOnly();

        protected BasePlayerSequence(IEnumerable<IPlayer> players, PlayerSequenceRandomizationOptions randomizationOptions,
            int minPlayers, int maxPlayers)
        {
            var random = new Random();

            if ((randomizationOptions & PlayerSequenceRandomizationOptions.RandomizeOrder) != 0)
            {
                _players = players.OrderBy(_ => random.Next()).ToList();
            }
            else 
            {
                _players = players.ToList();
            }

            if (!_players.Any()) throw new ArgumentException("Players collection cannot be empty.", nameof(players));

            ArgumentOutOfRangeException.ThrowIfLessThan(_players.Count, minPlayers, nameof(players));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(_players.Count, maxPlayers, nameof(players));

            if ((randomizationOptions & PlayerSequenceRandomizationOptions.RandomizeFirstMove) != 0)
            {
                CurrentPlayerIndex = random.Next(-1, _players.Count - 1);
            }
        }

        public IPlayer Next {             
            get
            {
                CurrentPlayerIndex = DetermineNextPlayerIndex(CurrentPlayerIndex);
                return _players[CurrentPlayerIndex];
            }
        }

        protected abstract int DetermineNextPlayerIndex(int currentPlayerIndex);
    }
}
