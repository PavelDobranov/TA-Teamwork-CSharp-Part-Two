namespace DwarfWarrior
{
    using Interfaces;

    public class Stealth : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 10;

        public Stealth(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Stealth.InitHealth, Stealth.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            throw new System.NotImplementedException();
        }
    }
}