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

        public Coordinate GetShootingPoint()
        {
            int row = this.TopLeftPosition.Row + 1;
            int col = this.TopLeftPosition.Col + this.BodyWidth;

            return new Coordinate(row, col);
        }

        public void MoveLeft()
        {
            this.TopLeftPosition += new Coordinate(0, -1);
        }
        public void MoveRigth()
        {
            this.TopLeftPosition += new Coordinate(0, +1);
        }
        public void MoveUp()
        {
            this.TopLeftPosition += new Coordinate(-1, 0);
        }
        public void MoveDown()
        {
            this.TopLeftPosition += new Coordinate(+1, 0);
        }
    }
}