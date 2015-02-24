namespace DwarfWarrior
{
    using System;
    using System.Text;

    using Interfaces;

    public abstract class GameObject : IRenderable, ICollidable
    {
        private char[,] body;

        public GameObject(Coordinate topLeftPosition, int health, int damage, Coordinate speed, char[,] body)
        {
            this.Type = this.ParseObjectType();
            this.TopLeftPosition = topLeftPosition;
            this.Health = health;
            this.Damage = damage;
            this.Speed = speed;
            this.Body = body;
            this.IsDestroyed = false;
        }

        public ObjectType Type { get; private set; }

        public Coordinate TopLeftPosition { get; protected set; }

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public Coordinate Speed { get; private set; }

        public char[,] Body
        {
            get
            {
                return this.CopyMatrix(this.body);
            }
            private set
            {
                this.body = this.CopyMatrix(value);
            }
        }

        public int BodyHeight
        {
            get
            {
                return this.Body.GetLength(0);
            }
        }

        public int BodyWidth
        {
            get
            {
                return this.Body.GetLength(1);
            }
        }

        public bool IsDestroyed { get; set; }

        public abstract bool CanCollideWith(ICollidable other);

        public virtual void RespondToCollision(ICollidable other)
        {
            this.Health -= other.Damage;

            if (this.Health <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        public abstract Coordinate[] GetShootingPoints();

        public virtual void Update()
        {
            this.TopLeftPosition += this.Speed;

           
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(this.BodyHeight);

            for (int row = 0; row < this.BodyHeight; row++)
            {
                for (int col = 0; col < this.BodyWidth; col++)
                {
                    result.Append(this.body[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private ObjectType ParseObjectType()
        {
            string currentObjectType = this.GetType().Name;

            return (ObjectType)Enum.Parse(typeof(ObjectType), currentObjectType);
        }

        private char[,] CopyMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrix[row, col];
                }
            }

            return result;
        }
    }
}