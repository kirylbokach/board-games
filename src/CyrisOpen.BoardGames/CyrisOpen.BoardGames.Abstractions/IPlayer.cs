namespace CyrisOpen.BoardGames.Abstractions;

/// <summary>
/// Abstraction for a person or entity that plays a game
/// </summary>
public interface IPlayer
{
    string Name { get; set; }

    TMove PlayTurn<TBoardSetup, TMove>(IBoard<TBoardSetup, TMove> board);

    TMove ReplayMove<TBoardSetup, TMove>(IBoard<TBoardSetup, TMove> board, TMove incorrectMove, MoveOutcome incorrectMoveOutcome);

    void AnalyzeMoveOutcome<TBoardSetup, TMove>(IPlayer player, IBoard<TBoardSetup, TMove> board, TMove move, MoveOutcome outcome);

    void AnalyzeGameOutcome<TBoardSetup, TMove>(IBoard<TBoardSetup, TMove> board);

    IReadOnlyCollection<PlayerGameStats> Stats { get; }
}
