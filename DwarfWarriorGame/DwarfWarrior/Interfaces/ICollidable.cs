namespace DwarfWarrior.Interfaces
{
    using System.Collections.Generic;

    using DwarfWarrior.GameObjects;

    public interface ICollidable
    {
        ObjectType Type { get; }

        int Health { get; }

        int Damage { get; }

        bool CanCollideWith(ICollidable other);

        void RespondToCollision(ICollidable other);

        List<Coordinate> GetCollisionProfile();
    }
}