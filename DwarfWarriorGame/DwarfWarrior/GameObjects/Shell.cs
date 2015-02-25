namespace DwarfWarrior.GameObjects
{
    using DwarfWarrior.Interfaces;

    public class Shell : GameObject, IRenderable, ICollidable
    {
        private const int InitHealth = 1;
        private const int InitDamage = 1;

        public Shell(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Shell.InitHealth, Shell.InitDamage, speed, body)
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