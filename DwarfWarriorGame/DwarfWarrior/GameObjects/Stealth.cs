namespace DwarfWarrior.GameObjects
{
    using DwarfWarrior.Interfaces;

    public class Stealth : ShootingObject, IRenderable, ICollidable, IShootable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;

        public Stealth(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Stealth.InitHealth, Stealth.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            return other.Type == ObjectType.Player || other.Type == ObjectType.Shell;
        }

        public override bool CanShootAt(GameObject other)
        {
            Coordinate shootingPoint = this.GetShootingPoint();
            int targetCol = other.TopLeftPosition.Col;

            for (int col = 0; col < other.BodyWidth; col++)
            {
                if (shootingPoint.Col == targetCol)
                {
                    return true;
                }

                targetCol++;
            }

            return false;
        }

        public override Coordinate GetShootingPoint()
        {
            int shootingPointRow = this.TopLeftPosition.Row + 1;
            int shootingPointCol = this.TopLeftPosition.Col + 2;

            return new Coordinate(shootingPointRow, shootingPointCol);
        }
    }
}