namespace DwarfWarrior
{
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        private ConsoleRenderer renderer;
        // game controller
        List<GameObject> gameObjects;
        // player

        public Engine()
        {
            this.renderer = new ConsoleRenderer(ConsoleUIObjects.GameRows, ConsoleUIObjects.GameCols);
            this.gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject obj)
        {
            this.gameObjects.Add(obj);
        }

        public void Run()
        {
            while (true)
            {
                foreach (var gameObject in this.gameObjects)
                {
                    this.renderer.AddToBuffer(gameObject);
                }

                this.renderer.RenderAll();

                Thread.Sleep(ConsoleUIObjects.GameSpeed);

                this.renderer.ClearBuffer();

                foreach (var gameObject in this.gameObjects)
                {
                    gameObject.Update();

                    if (gameObject.TopLeftPosition.Col < 0 - gameObject.BodyWidth ||
                        gameObject.TopLeftPosition.Row < 0 - gameObject.BodyHeight ||
                        gameObject.TopLeftPosition.Col >= ConsoleUIObjects.GameCols ||
                        gameObject.TopLeftPosition.Row >= ConsoleUIObjects.GameRows)
                    {
                        gameObject.IsDestroyed = true;
                    }
                }

                this.gameObjects.RemoveAll(o => o.IsDestroyed);

                if (this.gameObjects.Count == 0)
                {
                    break;
                }

            }
        }
    }
}