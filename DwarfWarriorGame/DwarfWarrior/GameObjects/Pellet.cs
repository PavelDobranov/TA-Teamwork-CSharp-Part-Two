namespace DwarfWarrior.GameObjects
{
    using DwarfWarrior.Interfaces;

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
            return other.Type == ObjectType.Battlecruiser ||
                   other.Type == ObjectType.Carrier ||
                   other.Type == ObjectType.Dragon ||
                   other.Type == ObjectType.Player ||
                   other.Type == ObjectType.Shell ||
                   other.Type == ObjectType.Stealth;
        }
    }
}