namespace DwarfWarrior
{
    using Interfaces;

    public class Battlecruiser : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 10;

        public Battlecruiser(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Battlecruiser.InitHealth, Battlecruiser.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            throw new System.NotImplementedException();
        }
    }
}