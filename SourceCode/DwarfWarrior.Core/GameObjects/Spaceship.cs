namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;
    using System;

    public abstract class Spaceship : SpaceUnit, IRenderable, IMovable, ICollidable, IShootable
    {
        private int shootingPointRow;
        private int shootingPointCol;
        protected int loopTicks;

        public Spaceship(Coordinate topLeftPosition, Coordinate speed, int health, int damage, string collisionGroupString, int shootingPointRow, int shootingPointCol, int shootingTicks, char[,] body)
            : base(topLeftPosition, speed, health, damage, collisionGroupString, body)
        {
            this.shootingPointRow = shootingPointRow;
            this.shootingPointCol = shootingPointCol;
            this.loopTicks = 0;
            this.ShootingTicks = shootingTicks;
        }

        public int ShootingTicks { get; private set; }

        public virtual Coordinate GetShootingPoint() 
        {
            return new Coordinate(this.TopLeftPosition.Row + shootingPointRow, this.TopLeftPosition.Col + shootingPointCol);
        }

        public virtual bool CanShootAt(GameObject other)
        {
            if (this.CollisionGroupString == "player")
            {
                return true;
            }

            int targetRow = other.TopLeftPosition.Row;

            for (int row = 0; row < other.BodyHeight; row++)
            {
                if (this.GetShootingPoint().Row == targetRow && this.IsReadyForShooting() && this.TopLeftPosition.Col > other.TopLeftPosition.Col)
                {
                    this.loopTicks = 0;
                    return true;
                }

                targetRow++;
            }

            return false;
        }

        protected virtual bool IsReadyForShooting()
        {
            return this.loopTicks >= this.ShootingTicks;
        }

        public override void Update()
        {
            base.Update();

            if (this.loopTicks < this.ShootingTicks)
            {
                this.loopTicks++;
            }
        }
    }
}