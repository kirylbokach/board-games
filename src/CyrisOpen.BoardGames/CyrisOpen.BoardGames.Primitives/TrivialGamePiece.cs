using CyrisOpen.BoardGames.Abstractions;

namespace CyrisOpen.BoardGames.Primitives
{
    public record TrivialGamePiece : IPlayerPiece
    {
        public IPlayer Owner { get; }

        private ConsoleColor Color { get; }

        private char Symbol { get; }

        public TrivialGamePiece(IPlayer owner, ConsoleColor color, char symbol)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Color = color;
            Symbol = symbol;
        }
    }
}
