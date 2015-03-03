namespace DwarfWarrior.Core.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using DwarfWarrior.Core.Interfaces;
    using DwarfWarrior.Core.GameObjects;

    public static class CollisionManager
    {
        public static void HandleCollisions(List<SpaceUnit> spaceUnits)
        {
            foreach (var spaceUnit in spaceUnits)
            {
                var currentUnitCollisionProfile = spaceUnit.GetCollisionProfile();

                var collidedUnits = spaceUnits.FindAll(su => su.GetCollisionProfile().Any(c => currentUnitCollisionProfile.Contains(c)));

                foreach (var unit in collidedUnits)
                {
                    if (unit == spaceUnit)
                    {
                        continue;
                    }

                    if (spaceUnit.CanCollideWith(unit))
                    {
                        spaceUnit.RespondToCollision(unit);
                    }
                }
            }
        }
    }
}
