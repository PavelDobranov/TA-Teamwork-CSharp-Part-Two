namespace DwarfWarrior
{
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        public const int gameRows = 25;
        public const int gameCols = 50;
        public const int gameSpeed = 100;
        
        private ConsoleRenderer renderer;
        // game controller
        List<GameObject> gameObjects;
        // player


        public Engine()
        {
            this.renderer = new ConsoleRenderer(Engine.gameRows, Engine.gameCols);
            this.gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject obj)
        {
            this.gameObjects.Add(obj);
        }
        public void Run()
        {

            int counter = 0;
            while (true)
            {
                foreach (var gameObject in this.gameObjects)
                {
                    renderer.AddToBuffer(gameObject);
                }

                renderer.RenderAll();
                Thread.Sleep(gameSpeed);
                renderer.ClearBuffer();
                foreach (var gameObject in this.gameObjects)
                {
                    gameObject.Update();

                    if (gameObject.IsDestroyed)
                    {
                        counter++;
                    }
                    if (counter == 4) break;
                }
            }
        }
    }
}
