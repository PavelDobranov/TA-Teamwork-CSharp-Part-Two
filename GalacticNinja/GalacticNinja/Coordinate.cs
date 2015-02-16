namespace GalacticNinja
{
    using System;

    public struct Coordinate
    {
        public Coordinate(int row, int col)
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
            throw new NotImplementedException();
        }

        public override bool Equals(Coordinate other)
        {
            return this.Row == other.Row && this.Col == other.Col;
        }
    }
}