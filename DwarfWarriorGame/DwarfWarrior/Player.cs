namespace DwarfWarrior
{
    using Interfaces;

    public class Player : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 10;

        public Player(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Player.InitHealth, Player.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            return other.Type == ObjectType.Battlecruiser ||
                   other.Type == ObjectType.Carrier ||
                   other.Type == ObjectType.Dragon ||
                   other.Type == ObjectType.Pellet ||
                   other.Type == ObjectType.Stealth;
        }
    }
}