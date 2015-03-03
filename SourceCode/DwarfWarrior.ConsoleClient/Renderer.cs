namespace DwarfWarrior.ConsoleClient
{
    using System;
    using System.Text;

    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class Renderer : IRenderer
    {
        private const char EmptyCellChar = ' ';

        private int bufferRows;
        private int bufferColumns;
        private int bufferStartRow;
        private int bufferStartCol;
        private char[,] buffer;

        public Renderer(int rows, int columns, Coordinate bufferPosition)
        {
            this.bufferRows = rows;
            this.bufferColumns = columns;
            this.bufferStartRow = bufferPosition.Row;
            this.bufferStartCol = bufferPosition.Col;
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

            for (int row = objectBodyStartRow; row <= objectBodyEndRow; row++)
            {
                int objectBodyCurrentCol = 0;

                for (int col = objectBodyStartCol; col <= objectBodyEndCol; col++)
                {
                    if (row >= 0 && row < buffer.GetLength(0) && col >= 0 && col < buffer.GetLength(1))
                    {
                        if (objectBody[objectBodyCurrentRow, objectBodyCurrentCol] != EmptyCellChar)
                        {
                            buffer[row, col] = objectBody[objectBodyCurrentRow, objectBodyCurrentCol];
                        }
                    }

                    objectBodyCurrentCol++;
                }

                objectBodyCurrentRow++;
            }
        }

        public void RenderBuffer()
        {
            int sceneStartRow = this.bufferStartRow;
            int sceneStartCol = this.bufferStartCol;

            Console.SetCursorPosition(sceneStartCol, sceneStartRow);

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
                    if (this.buffer[row, col] != EmptyCellChar)
                    {
                        this.buffer[row, col] = EmptyCellChar;
                    }
                }
            }
        }

        public void RenderAtPosition(string text, Coordinate position)
        {
            Console.SetCursorPosition(position.Col, position.Row);

            Console.Write(text);
        }

        public void RenderAtPosition(char[,] matrix, Coordinate position)
        {
            StringBuilder currentRow = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                currentRow = new StringBuilder();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    currentRow.Append(matrix[row, col]);
                }

                this.RenderAtPosition(currentRow.ToString(), position);

                position.Row++;
            }
        }
    }
}