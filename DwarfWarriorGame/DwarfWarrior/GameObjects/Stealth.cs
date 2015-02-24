namespace DwarfWarrior.GameObjects
{
    using DwarfWarrior.Interfaces;

    public class Stealth : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;

        public Stealth(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Stealth.InitHealth, Stealth.InitDamage, speed, body)
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
            int currentShootingPointRow = this.TopLeftPosition.Row + 1;
            int currentShootingPointCol = this.TopLeftPosition.Col + 2;
            Coordinate[] shootingPoints = new Coordinate[1];
            shootingPoints[0] = new Coordinate(currentShootingPointRow, currentShootingPointCol);

            return shootingPoints;
        }
    }
}