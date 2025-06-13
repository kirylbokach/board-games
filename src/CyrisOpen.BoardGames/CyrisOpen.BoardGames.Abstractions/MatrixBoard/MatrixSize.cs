namespace CyrisOpen.BoardGames.Abstractions.MatrixBoard
{
    public record MatrixSize
    {
        public int Rows { get; init; }
        public int Columns { get; init; }

        public MatrixSize(int rows, int columns)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(rows, 1, nameof(rows));
            ArgumentOutOfRangeException.ThrowIfLessThan(columns, 1, nameof(columns));
            
            Rows = rows;
            Columns = columns;
        }

        public override string ToString() => $"{Rows}x{Columns}";
    }
}
