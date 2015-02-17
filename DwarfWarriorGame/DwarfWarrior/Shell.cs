﻿namespace DwarfWarrior
{
    using Interfaces;

    public class Shell : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 1;

        public Shell(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Shell.InitHealth, Shell.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            throw new System.NotImplementedException();
        }
    }
}