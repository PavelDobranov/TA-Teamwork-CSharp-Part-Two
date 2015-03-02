namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Interfaces;
    using DwarfWarrior.Core.Helpers;

    public class Carrier : Spaceship, IRenderable, IMovable, ICollidable, IShootable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 10;
        private const int InitShootingTicks = 10;
        private const int InitShootingPointRow = 1;
        private const int InitShootingPointCol = -1;

        public Carrier(Coordinate topLeftPosition, Coordinate speed, string collisionGroupString, char[,] body)
            : base(topLeftPosition, speed, InitHealth, InitDamage, collisionGroupString, InitShootingPointRow, InitShootingPointCol, InitShootingTicks, body)
        {
        }
    }
}