namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class Shell : SpaceUnit, IRenderable, IMovable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 1;

        public Shell(Coordinate topLeftPosition, Coordinate speed, string collisionGroupString, char[,] body)
            : base(topLeftPosition, speed, InitHealth, InitDamage, collisionGroupString, body)
        {
        }
    }
}