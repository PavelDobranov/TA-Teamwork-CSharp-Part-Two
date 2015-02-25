namespace DwarfWarrior
{
    using DwarfWarrior.GameObjects;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public static class CollisionManager
    {
        public static void HandleCollisions(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var currentObjectCollisionProfile = gameObject.GetCollisionProfile();

                var collideObjects = gameObjects.FindAll(o => o.GetCollisionProfile().Any(c => currentObjectCollisionProfile.Contains(c)));

                foreach (var collideObject in collideObjects)
                {
                    if (collideObject == gameObject)
                    {
                        continue;
                    }

                    if (gameObject.CanCollideWith(collideObject))
                    {
                        gameObject.RespondToCollision(collideObject);
                    }
                }
            }
        }
    }
}
