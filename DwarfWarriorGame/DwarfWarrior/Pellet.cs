namespace DwarfWarrior
{
    using Interfaces;

    public class Pellet : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 1;

        public Pellet(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Pellet.InitHealth, Pellet.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            throw new System.NotImplementedException();
        }
    }
}