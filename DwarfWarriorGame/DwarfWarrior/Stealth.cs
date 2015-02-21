namespace DwarfWarrior
{
    using Interfaces;

    public class Stealth : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;

        public Stealth(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Stealth.InitHealth, Stealth.InitDamage, speed, body)
        {
        }

        public Coordinate[] GetShootingPoints()
        {
            int currentShootingPointRow = this.TopLeftPosition.Row + 1;
            int currentShootingPointCol = this.TopLeftPosition.Col + 2;
            Coordinate[] shootingPoints = new Coordinate[1];
            shootingPoints[0] = new Coordinate(currentShootingPointRow, currentShootingPointCol);

            return shootingPoints;
        }
    }
}