namespace DwarfWarrior
{
    public struct Coordinate
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Coordinate(int row, int col) : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.Row + b.Row, a.Col + b.Col);
        }

        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.Row - b.Row, a.Col - b.Col);
        }

        public override bool Equals(object obj)
        {
            Coordinate objAsCoordinate = (Coordinate)obj;

            return objAsCoordinate.Row == this.Row && objAsCoordinate.Col == this.Col;
        }
    }
}