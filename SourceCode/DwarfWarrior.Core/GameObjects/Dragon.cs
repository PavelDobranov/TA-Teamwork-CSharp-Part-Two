namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Interfaces;
    using DwarfWarrior.Core.Helpers;

    public class Dragon : Spaceship, IRenderable, IMovable, ICollidable, IShootable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;
        private const int InitShootingTicks = 20;
        private const int InitShootingPointRow = -1;
        private const int InitShootingPointCol = 2;

        public Dragon(Coordinate topLeftPosition, Coordinate speed, string collisionGroupString, char[,] body)
            : base(topLeftPosition, speed, InitHealth, InitDamage, collisionGroupString, InitShootingPointRow, InitShootingPointCol, InitShootingTicks, body)
        {
        }

        public override bool CanShootAt(GameObject other)
        {
            int targetCol = other.TopLeftPosition.Col;

            for (int col = 0; col < other.BodyWidth; col++)
            {
                if (this.GetShootingPoint().Col == targetCol && this.IsReadyForShooting())
                {
                    this.loopTicks = 0;
                    return true;
                }

                targetCol++;
            }

            return false;
        }
    }
}