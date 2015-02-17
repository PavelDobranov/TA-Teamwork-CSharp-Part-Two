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
            throw new System.NotImplementedException();
        }
    }
}
