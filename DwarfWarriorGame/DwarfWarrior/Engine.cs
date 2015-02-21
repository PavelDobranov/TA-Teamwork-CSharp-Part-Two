namespace DwarfWarrior
{
    using System.Collections.Generic;
    using System.Threading;
    using Interfaces;
    using System;

    public class Engine
    {
        private IGameController gameController;
        private IRenderer renderer;
        private GameObjectsFactory objectFactory;
        List<GameObject> gameObjects;
        Player player;

        public Engine(IGameController gameController, IRenderer renderer, GameObjectsFactory objectFactory, Player player)
        {
            this.gameController = gameController;
            this.renderer = renderer;
            this.objectFactory = objectFactory;
            this.gameObjects = new List<GameObject>();
            this.player = player;

        }

        public void AddGameObject(GameObject obj)
        {
            this.gameObjects.Add(obj);
        }

        public void AddPlayer()
        {
            gameObjects.Add(this.player);
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

                gameController.ProcessInput();

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

                //if (this.gameObjects.Count == 0)
                //{
                //    break;
                //}

            }
        }

        public void MovePlayerUp()
        {
            if (player.TopLeftPosition.Row > 0)
            {
                this.player.MoveUp();

            }

        }

        public void MovePlayerDown()
        {
            this.player.MoveDown();
        }

        public void MovePlayerLeft()
        {
            this.player.MoveLeft();
        }

        public void MovePlayerRight()
        {
            this.player.MoveRigth();
        }

        internal void PlayerShoot()
        {
            Coordinate shellPosition = player.GetShootingPoint();
            int shellSpeedRow = 0;
            int shellSpeedCol = 1;

            GameObject shell = objectFactory.ProduceObject(ObjectType.Shell, shellPosition.Row, shellPosition.Col, shellSpeedRow, shellSpeedCol) as Shell;

            this.AddGameObject(shell);
        }

    }
}