namespace DwarfWarrior
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Interfaces;

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

                Thread.Sleep(ConsoleUI.GameSpeed);

                gameController.ProcessInput();

                this.renderer.ClearBuffer();

                foreach (var gameObject in this.gameObjects)
                {
                    gameObject.Update();

                    if (gameObject.TopLeftPosition.Col < 0 - gameObject.BodyWidth ||
                        gameObject.TopLeftPosition.Row < 0 - gameObject.BodyHeight ||
                        gameObject.TopLeftPosition.Col >= ConsoleUI.GameCols ||
                        gameObject.TopLeftPosition.Row >= ConsoleUI.GameRows)
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

        public void ObjectProduceShoot(GameObject gameObject)
        {
            Coordinate[] shootingPoints = gameObject.GetShootingPoints();
            int shootingPointSpeedRow = 0;
            int shootingPointSpeedCol = 0;
            ObjectType producedObjectType = ObjectType.Pellet;

            switch (gameObject.Type)
            {
                case ObjectType.Player:
                    shootingPointSpeedRow = 0;
                    shootingPointSpeedCol = 1;
                    producedObjectType = ObjectType.Shell;
                    break;
                case ObjectType.Battlecruiser:
                case ObjectType.Carrier:
                    shootingPointSpeedRow = 0;
                    shootingPointSpeedCol = -1;
                    break;
                case ObjectType.Dragon:
                    shootingPointSpeedRow = -1;
                    shootingPointSpeedCol = -1;
                    break;
                case ObjectType.Stealth:
                    shootingPointSpeedRow = 1;
                    shootingPointSpeedCol = 0;
                    break;
            }

            int shootingPointRow = shootingPoints[0].Row;
            int shootingPointCol = shootingPoints[0].Col;

            for (int point = 0; point < shootingPoints.Length; point++)
            {
                GameObject cuurentObject = objectFactory.ProduceObject(producedObjectType, shootingPointRow, shootingPointCol, shootingPointSpeedRow, shootingPointSpeedCol);

                this.AddGameObject(cuurentObject);

                ++shootingPointCol;
                ++shootingPointSpeedCol;
            }
        }
    }
}