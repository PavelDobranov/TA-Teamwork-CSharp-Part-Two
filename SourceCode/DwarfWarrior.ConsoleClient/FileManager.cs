namespace DwarfWarrior.ConsoleClient
{
    using System.Collections.Generic;
    using System.IO;

    public static class FileManager
    {
        private const string FilePath = @"..\..\HighScore\HighScore.txt";
        public static char[,] TextFileToCharMatrix(string filePath)
        {
            var reader = new StreamReader(filePath);

            using (reader)
            {
                int matrixRows = int.Parse(reader.ReadLine());
                int matrixCols = int.Parse(reader.ReadLine());

                char[,] matrix = new char[matrixRows, matrixCols];

                for (int row = 0; row < matrixRows; row++)
                {
                    string currentRow = reader.ReadLine();

                    for (int col = 0; col < matrixCols; col++)
                    {
                        matrix[row, col] = currentRow[col];
                    }
                }

                return matrix;
            }
        }
        public static void SaveHighScore(Dictionary<int, string> highscore)
        {
            var writer = new StreamWriter(FilePath, false);
            using (writer)
            {
                foreach (var item in highscore)
                {
                    writer.WriteLine(item.Key + " " + item.Value);
                }
            }
        }
        public static Dictionary<int, string> ParseHighScore()
        {
            Dictionary<int,string> highScore = new Dictionary<int,string>();
            var reader = new StreamReader(FilePath);
            using (reader)
            {
                
                string tempLine = reader.ReadLine();
                do
                {
                    string[] currentLine = tempLine.Split(' ');
                    highScore.Add(int.Parse(currentLine[0]),currentLine[1]);
                    tempLine = reader.ReadLine();

                } while (tempLine != null);
            }
            return highScore;
        }
    }
}