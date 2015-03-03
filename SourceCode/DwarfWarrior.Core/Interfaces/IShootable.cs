namespace DwarfWarrior.Core.Interfaces
{
    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;

    public interface IShootable
    {
        int ShootingTicks { get; }

        Coordinate GetShootingPoint();

        bool CanShootAt(GameObject other);
    }
}