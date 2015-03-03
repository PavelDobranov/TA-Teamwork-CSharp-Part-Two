namespace DwarfWarrior.Core.Helpers
{
    public struct Coordinate
    {
        public Coordinate(int row, int col) : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public static Coordinate operator +(Coordinate first, Coordinate second)
        {
            return new Coordinate(first.Row + second.Row, first.Col + second.Col);
        }

        public static Coordinate operator -(Coordinate first, Coordinate second)
        {
            return new Coordinate(first.Row - second.Row, first.Col - second.Col);
        }

        public override bool Equals(object obj)
        {
            Coordinate objAsCoordinate = (Coordinate)obj;

            return objAsCoordinate.Row == this.Row && objAsCoordinate.Col == this.Col;
        }
    }
}