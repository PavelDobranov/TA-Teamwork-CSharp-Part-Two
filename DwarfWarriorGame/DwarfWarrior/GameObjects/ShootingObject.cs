namespace DwarfWarrior.GameObjects
{
    using System.Collections.Generic;

    using DwarfWarrior.Interfaces;

    public abstract class ShootingObject : GameObject, IRenderable, ICollidable, IShootable
    {
        public ShootingObject(Coordinate topLeftPosition, int health, int damage, Coordinate speed, char[,] body)
            : base(topLeftPosition, health, damage, speed, body)
        {
        }

        public virtual bool CanShootAt(GameObject other)
        {
            Coordinate shootingPoint = this.GetShootingPoint();
            int targetRow = other.TopLeftPosition.Row;

            for (int row = 0; row < other.BodyHeight; row++)
            {
                if (shootingPoint.Row == targetRow)
                {
                    return true;
                }

                targetRow++;
            }

            return false;
        }

        public virtual Coordinate GetShootingPoint()
        {
            int shootingPointRow = this.TopLeftPosition.Row + 1;
            int shootingPointCol = this.TopLeftPosition.Col - 1;

            return new Coordinate(shootingPointRow, shootingPointCol);
        }
    }
}