namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class SpaceParticle : SpaceUnit, IRenderable, IMovable, ICollidable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 0;

        public SpaceParticle(Coordinate topLeftPosition, Coordinate speed, string collisionGroupString, char[,] body)
            : base(topLeftPosition, speed, InitHealth, InitDamage, collisionGroupString, body)
        {
        }

        public override void Update()
        {
            this.Health--;
            base.Update();
        }
    }
}
