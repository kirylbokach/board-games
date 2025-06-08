namespace CyrisOpen.BoardGames.Abstractions;

/// <summary>
/// Abstraction for a person or entity that plays a game
/// </summary>
public interface IPlayer
{
    string Name { get; set; }

    void PlayTurn(IBoard board);
}
