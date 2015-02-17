namespace DwarfWarrior
{
    using Interfaces;

    public class Carrier : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 10;

        public Carrier(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Carrier.InitHealth, Carrier.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            throw new System.NotImplementedException();
        }
    }
}