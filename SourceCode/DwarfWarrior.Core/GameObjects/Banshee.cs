namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Interfaces;
    using DwarfWarrior.Core.Helpers;

    public class Banshee : Spaceship, IRenderable, IMovable, ICollidable, IShootable
    {
        private const int InitHealth = 4;
        private const int InitDamage = 10;
        private const int InitShootingTicks = 3;
        private const int InitShootingPointRow = 1;
        private const int InitShootingPointCol = 12;

        public Banshee(Coordinate topLeftPosition, Coordinate speed, string collisionGroupString, char[,] body)
            : base(topLeftPosition, speed, InitHealth, InitDamage, collisionGroupString, InitShootingPointRow, InitShootingPointCol, InitShootingTicks, body)
        {
        }
    }
}