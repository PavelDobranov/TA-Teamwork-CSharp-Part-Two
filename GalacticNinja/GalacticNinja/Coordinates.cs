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
            throw new NotImplementedException();
        }

        public static Coordinate operator -(Coordinate first, Coordinate second)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
