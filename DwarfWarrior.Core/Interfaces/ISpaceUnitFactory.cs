namespace DwarfWarrior.Core.Interfaces
{
    using System.Collections.Generic;

    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;

    public interface ISpaceUnitFactory
    {
        SpaceUnit ProduceSpaceUnit(SpaceUnitType type, Coordinate position, Coordinate speed, string collisionGroupString);

        SpaceUnit ProduceRandomSpaceUnit(string collisionGroupString);

        List<SpaceUnit> ProduceShellsFrom(Spaceship spaceship);
    }
}
