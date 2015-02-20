namespace DwarfWarrior
{
    using Interfaces;
    using System;
    using System.Text;

    public class ConsoleRenderer : IRenderer
    {
        private int matrixContextRows;
        private int matrixContextCols;
        private char[,] matrixContext;

        public ConsoleRenderer(int rows, int cols)
        {
            this.matrixContextRows = rows;
            this.matrixContextCols = cols;
            this.matrixContext = new char[rows, cols];
        }

        public void AddToBuffer(GameObject obj)
        {
            Coordinate objectTopLeftPosition = obj.TopLeftPosition;
            char[,] objectBody = obj.Body;
            int objectBodyRows = obj.BodyHeight;
            int objectBodyCols = obj.BodyWidth;

            int objectBodyCurrentRow = 0;

            for (int row = objectTopLeftPosition.Row; row < objectTopLeftPosition.Row + objectBodyRows; row++)
            {
                int objectBodyCurrentCol = 0;
                for (int col = objectTopLeftPosition.Col; col < objectTopLeftPosition.Col + objectBodyCols; col++)
                {
                    matrixContext[row, col] = objectBody[objectBodyCurrentRow, objectBodyCurrentCol];
                    ++objectBodyCurrentCol;
                }
                ++objectBodyCurrentRow;
            }
        }

        public void RenderAll()
        {
            StringBuilder scene = new StringBuilder();
            for (int row = 0; row < this.matrixContextRows; row++)
            {
                for (int col = 0; col < this.matrixContextCols; col++)
                {
                    scene.Append(matrixContext[row, col]);
                }
                scene.Append(Environment.NewLine);
            }
        }

        public void ClearBuffer()
        {
            for (int row = 0; row < this.matrixContextRows; row++)
            {
                for (int col = 0; col < this.matrixContextCols; col++)
                {
                    this.matrixContext[row, col] = ' ';
                }
            }
        }
    }
}
