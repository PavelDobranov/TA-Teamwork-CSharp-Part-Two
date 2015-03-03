namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class GameObject : IRenderable
    {
        private char[,] body;

        public GameObject(Coordinate topLeftPosition, char[,] body)
        {
            this.TopLeftPosition = topLeftPosition;
            this.Body = body;
        }

        public Coordinate TopLeftPosition { get; set; }

        public bool IsDestroyed { get; set; }

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