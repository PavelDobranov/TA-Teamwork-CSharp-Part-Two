namespace DwarfWarrior.ConsoleClient
{
    using System;
    using System.Text;

    using Interfaces;
    using GameObjects;

    public class ConsoleRenderer : IRenderer
    {
        private int bufferRows;
        private int bufferColumns;
        private char[,] buffer;

        public ConsoleRenderer(int rows, int columns)
        {
            this.bufferRows = rows;
            this.bufferColumns = columns;
            this.buffer = new char[rows, columns];
            this.ClearBuffer();
        }

        public void AddToBuffer(GameObject gameObject)
        {
            Coordinate objectTopLeftPosition = gameObject.TopLeftPosition;
            
            char[,] objectBody = gameObject.Body;

            int objectBodyStartRow = gameObject.TopLeftPosition.Row;
            int objectBodyStartCol = gameObject.TopLeftPosition.Col;
            
            int objectBodyEndRow = gameObject.TopLeftPosition.Row + gameObject.BodyHeight - 1;
            int objectBodyEndCol = gameObject.TopLeftPosition.Col + gameObject.BodyWidth - 1;

            int objectBodyCurrentRow = 0;

            for (int matrixRow = objectBodyStartRow; matrixRow <= objectBodyEndRow; matrixRow++)
            {
                int objectBodyCurrentCol = 0;
                
                for (int matrixCol = objectBodyStartCol; matrixCol <= objectBodyEndCol; matrixCol++)
                {
                    if (matrixRow >= 0 && matrixRow < buffer.GetLength(0) &&
                        matrixCol >= 0 && matrixCol < buffer.GetLength(1))
                    {
                        buffer[matrixRow, matrixCol] = objectBody[objectBodyCurrentRow, objectBodyCurrentCol];
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

            for (int row = 0; row < this.bufferRows; row++)
            {
                for (int col = 0; col < this.bufferColumns; col++)
                {
                    scene.Append(buffer[row, col]);
                }
                scene.Append(Environment.NewLine);
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearBuffer()
        {
            for (int row = 0; row < this.bufferRows; row++)
            {
                for (int col = 0; col < this.bufferColumns; col++)
                {
                    this.buffer[row, col] = ' ';
                }
            }
        }
    }
}
