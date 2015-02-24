namespace DwarfWarrior
{
    using System;
    using System.Collections;
    using System.IO;

    class Program
    {
        private static int currentScore = 0;
        private static string nickName;

        public static void SaveScore()
        {
            ArrayList scores = new ArrayList(10);
            string line = "";
            int lineCount = 0;

            try
            {
                StreamReader reader = new StreamReader("..\\..\\High.Score");
                //reads all scores a save them in a List

                while ((line = reader.ReadLine()) != null)
                {
                    int indexOfSplit = line.IndexOf(' ');
                    string points = line.Substring(0, indexOfSplit);
                    string name = line.Substring(indexOfSplit + 1);
                    string[] score = new string[] { points, name };
                    scores.Add(score);
                    lineCount++;
                }
                reader.Close();
                //Append new high score if they are less than 10
                int finalPos = 0;
                foreach (string[] scoreLines in scores)
                {
                    if (currentScore > int.Parse(scoreLines[0])) break;
                    finalPos++;
                    if (finalPos > 9) break;
                }
                scores.Insert(finalPos, new string[] { currentScore.ToString(), nickName });
                StreamWriter writer = new StreamWriter("..\\..\\High.Score");
                for (int i = 0; i < 10 && i < scores.Count; i++)
                {
                    writer.WriteLine(((string[])scores[i])[0] + " " + ((string[])scores[i])[1]);
                }
                writer.Close();
            }
            catch (SystemException)
            {
                Console.WriteLine("Could not write to high score file, delete it to resolve conflict.");
            }
        }

        static void Main()
        {
            //set nickname on start
            nickName = string.Empty;
            while (nickName == string.Empty)
            {
                Console.CursorVisible = true;
                Console.SetCursorPosition(35, 16);
                Console.Write("Enter Nickname: ");
                nickName = Console.ReadLine().Trim();
                Console.CursorVisible = false;
            }
            Console.Clear();
            //int rows = 50;
            //int cols = 50;

            //var renderer = new ConsoleRenderer(rows, cols);
            //var factory = new GameObjectsFactory();
            //var pesho = factory.ProduceObject(ObjectType.Dragon, 22, 15, 0, 0);

            //renderer.AddToBuffer(pesho);
            //renderer.RenderAll();
            //Console.ReadLine();


            var keyboard = new KeyboardController();
            var renderer = new ConsoleRenderer(ConsoleUI.GameRows, ConsoleUI.GameCols);
            var factory = new GameObjectsFactory();
            var player = factory.ProduceObject(ObjectType.Player, 10, 10, 0, 0) as Player;
            var engine = new Engine(keyboard, renderer, factory, player);
            engine.AddPlayer();

            engine.AddGameObject(factory.ProduceObject(ObjectType.Battlecruiser, 0, 15, 0, 0));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Carrier, 4, ConsoleUIObjects.GameCols - 1, 0, -1));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Dragon, 8, ConsoleUIObjects.GameCols - 1, 0, -1));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Stealth, 12, ConsoleUIObjects.GameCols - 1, 0, -1));


            keyboard.OnUpPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Row > 0)
                {
                    engine.MovePlayerUp();
                }
            };

            keyboard.OnDownPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Row < ConsoleUI.GameRows - player.BodyHeight)
                {
                    engine.MovePlayerDown();
                }
            };

            keyboard.OnLeftPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Col > 0)
                {
                    engine.MovePlayerLeft();
                }
            };

            keyboard.OnRightPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Col < ConsoleUI.GameCols - player.BodyWidth)
                {
                    engine.MovePlayerRight();
                }
            };

            keyboard.OnActionPressed += (sender, eventinfo) =>
            {
                engine.ObjectProduceShoot(player);
            };


            engine.Run();


        }
    }
}