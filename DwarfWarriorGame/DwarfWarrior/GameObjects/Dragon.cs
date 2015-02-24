namespace DwarfWarrior
{
    using Interfaces;
    using System;

    public class Dragon : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;

        public Dragon(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Dragon.InitHealth, Dragon.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            return other.Type == ObjectType.Pellet ||
                   other.Type == ObjectType.Player ||
                   other.Type == ObjectType.Shell;
        }

        public override Coordinate[] GetShootingPoints()
        {
            int shootingPointsCounts = 3;
            int currentShootingPointRow = this.TopLeftPosition.Row - 1;
            int currentShootingPointCol = this.TopLeftPosition.Col + 1;

            Coordinate[] shootingPoints = new Coordinate[shootingPointsCounts];

            for (int i = 0; i < shootingPointsCounts; i++)
            {
                shootingPoints[i] = new Coordinate(currentShootingPointRow, currentShootingPointCol);
                ++currentShootingPointCol;
            }

            return shootingPoints;
        }
    }
}
