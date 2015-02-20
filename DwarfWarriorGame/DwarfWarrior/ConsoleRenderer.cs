namespace DwarfWarrior
{
    using System;
    using System.Text;
    using Interfaces;

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
            this.ClearBuffer();
        }

        public void AddToBuffer(GameObject obj)
        {
            Coordinate objectTopLeftPosition = obj.TopLeftPosition;
            char[,] objectBody = obj.Body;
            //int objectBodyRows = obj.BodyHeight;
            //int objectBodyCols = obj.BodyWidth;

            int objectBodyStartRow = obj.TopLeftPosition.Row;
            int objectBodyStartCol = obj.TopLeftPosition.Col;
            int objectBodyEndRow = obj.TopLeftPosition.Row + obj.BodyHeight - 1;
            int objectBodyEndCol = obj.TopLeftPosition.Col + obj.BodyWidth - 1;

            int objectBodyCurrentRow = 0;

            for (int matrixRow = objectBodyStartRow; matrixRow <= objectBodyEndRow; matrixRow++)
            {
                int objectBodyCurrentCol = 0;
                for (int matrixCol = objectBodyStartCol; matrixCol <= objectBodyEndCol; matrixCol++)
                {
                    if (matrixRow > 0 &&
                        matrixRow < matrixContext.GetLength(0) &&
                        matrixCol > 0 &&
                        matrixCol < matrixContext.GetLength(1))
                    {
                        matrixContext[matrixRow, matrixCol] = objectBody[objectBodyCurrentRow, objectBodyCurrentCol];
                    }
                    ++objectBodyCurrentCol;
                }

                ++objectBodyCurrentRow;
            }
        }

        public void RenderAll()
        {
            int sceneStartRow = 0;
            int sceneStartCol = 0;
            Console.SetCursorPosition(sceneStartRow, sceneStartCol);
            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.matrixContextRows; row++)
            {
                for (int col = 0; col < this.matrixContextCols; col++)
                {
                    scene.Append(matrixContext[row, col]);
                }
                scene.Append(Environment.NewLine);
            }
            Console.WriteLine(scene.ToString());
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
