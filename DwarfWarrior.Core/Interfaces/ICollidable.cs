namespace DwarfWarrior.Core.Interfaces
{
    using System.Collections.Generic;

    using DwarfWarrior.Core.Helpers;

    public interface ICollidable
    {
        int Health { get; }

        int Damage { get; }

        string CollisionGroupString { get; }

        bool CanCollideWith(ICollidable other);

        void RespondToCollision(ICollidable other);

        List<Coordinate> GetCollisionProfile();
    }
}