namespace CyrisOpen.BoardGames.Abstractions.MatrixBoard
{
    public record MatrixPosition
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public MatrixPosition(int row, int column, MatrixSize size)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(row, 0, nameof(row));
            ArgumentOutOfRangeException.ThrowIfLessThan(column, 0, nameof(column));
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(row, size.Rows, nameof(row));
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(column, size.Columns, nameof(column));

            Row = row;
            Column = column;
        }
        public override string ToString() => $"({Row}, {Column})";
    }
}
