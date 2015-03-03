namespace DwarfWarrior.Core.GameObjects
{
    using System;
    using System.Collections.Generic;
    
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public abstract class SpaceUnit : GameObject, IRenderable, IMovable, ICollidable
    {
        public SpaceUnit(Coordinate topLeftPosition, Coordinate speed, int health, int damage, string collisionGroupString, char[,] body)
            : base(topLeftPosition, body)
        {
            this.Type = this.ParseSpaceUnitType();
            this.Speed = speed;
            this.Health = health;
            this.Damage = damage;
            this.CollisionGroupString = collisionGroupString;
        }

        public SpaceUnitType Type { get; private set; }

        public Coordinate Speed { get; private set; }

        public int Health { get; protected set; }

        public int Damage { get; private set; }

        public string CollisionGroupString { get; private set; }

        public virtual bool CanCollideWith(ICollidable other)
        {
            if (this.CollisionGroupString == "player")
            {
                return other.CollisionGroupString == "enemy";
            }

            return other.CollisionGroupString == "player";
        }

        public virtual void RespondToCollision(ICollidable other) 
        {
            this.Health -= other.Damage;
        }

        public List<Coordinate> GetCollisionProfile()
        {
            List<Coordinate> collisionProfile = new List<Coordinate>();

            for (int row = 0; row < this.BodyHeight; row++)
            {
                for (int col = 0; col < this.BodyWidth; col++)
                {
                    if (char.IsSymbol(this.Body[row, col]) || !char.IsWhiteSpace(this.Body[row, col])) // TODO: Check for proper working!!!
                    {
                        collisionProfile.Add(new Coordinate(this.TopLeftPosition.Row + row, this.TopLeftPosition.Col + col));
                    }
                }
            }

            return collisionProfile;
        }

        public virtual void Update()
        {
            this.TopLeftPosition += this.Speed;

            if (this.Health <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        private SpaceUnitType ParseSpaceUnitType()
        {
            string currentObjectType = this.GetType().Name;

            return (SpaceUnitType)Enum.Parse(typeof(SpaceUnitType), currentObjectType);
        }
    }
}