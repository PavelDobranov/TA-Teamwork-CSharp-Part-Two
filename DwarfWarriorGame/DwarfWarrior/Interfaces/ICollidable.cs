namespace DwarfWarrior.Interfaces
{
    public interface ICollidable
    {
        ObjectType Type { get; }

        int Health { get; }

        int Damage { get; }

        bool CanCollideWith(ICollidable other);

        void RespondToCollision(ICollidable other);
    }
}