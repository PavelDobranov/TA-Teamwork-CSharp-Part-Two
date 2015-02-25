namespace DwarfWarrior
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;

    using DwarfWarrior.ConsoleClient;
    using DwarfWarrior.GameObjects;
    using DwarfWarrior.Interfaces;

    public class Engine
    {
        private const int SleepTimeInMs = 100;
        private IGameController gameController;
        private IRenderer renderer;
        private IGameObjectProducer objectFactory;
        private List<GameObject> gameObjects;
        private List<GameObject> producedObjects;
        private Random randomGenerator;
        private DateTime startTime;
        private Player player;

        public Engine(IGameController gameController, IRenderer renderer, IGameObjectProducer objectFactory, GameObject player)
        {
            this.gameController = gameController;
            this.renderer = renderer;
            this.objectFactory = objectFactory;
            this.gameObjects = new List<GameObject>();
            this.producedObjects = new List<GameObject>();
            this.randomGenerator = new Random();
            this.startTime = DateTime.Now;
            this.player = player as Player;
            this.AddGameObject(player);
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void MovePlayerUp()
        {
            this.player.MoveUp();
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


        public void Run()
        {
            while (true)
            {
                TimeSpan timer = DateTime.Now - this.startTime;

                if (timer.Seconds == this.randomGenerator.Next(1, 10))
                {
                    this.ProduceRandomEnemy();
                    this.startTime = DateTime.Now;
                }

                foreach (var gameObject in this.gameObjects)
                {
                    this.renderer.AddToBuffer(gameObject);
                }

                this.renderer.RenderAll();

                Thread.Sleep(Engine.SleepTimeInMs);

                gameController.UserInput();

                this.renderer.ClearBuffer();

                foreach (var gameObject in this.gameObjects)
                {
                    if (IsOutOfCanvas(gameObject))
                    {
                        gameObject.IsDestroyed = true;
                    }
                    else
                    {
                        gameObject.Update();
                    }

                    if (gameObject is ShootingObject && gameObject.Type != ObjectType.Player)
                    {
                        var currentObject = gameObject as ShootingObject;

                        var canShoot = currentObject.CanShootAt(this.player);

                        if (canShoot)
                        {
                            ProduceShotFrom(currentObject);
                        }
                    }
                }

                CollisionManager.HandleCollisions(this.gameObjects);

                this.gameObjects.RemoveAll(o => o.IsDestroyed);
                this.gameObjects.AddRange(this.producedObjects);
                this.producedObjects.Clear();

                // for testing purposes
                //if (this.gameObjects.Count == 1)
                //{
                //    this.seedGameObjects();
                //}
            }
        }

        private bool IsOutOfCanvas(GameObject gameObject)
        {
            return gameObject.TopLeftPosition.Col < -gameObject.BodyWidth ||
                   gameObject.TopLeftPosition.Row < -gameObject.BodyHeight ||
                   gameObject.TopLeftPosition.Col >= ConsoleUI.CanvasColumns ||
                   gameObject.TopLeftPosition.Row >= ConsoleUI.CanvasRows;
        }

        public void ProduceShotFrom(ShootingObject gameObject)
        {
            Coordinate shootingPoint = gameObject.GetShootingPoint();

            ObjectType producedObjectType = ObjectType.Pellet;
            int producedObjectSpeedRow = 0;
            int producedObjectSpeedCol = 0;
            int producedObjectsCount = 0;

            switch (gameObject.Type)
            {
                case ObjectType.Battlecruiser:
                case ObjectType.Carrier:
                    producedObjectSpeedRow = 0;
                    producedObjectSpeedCol = -5;
                    producedObjectsCount = 1;
                    break;
                case ObjectType.Dragon:
                    producedObjectSpeedRow = -1;
                    producedObjectSpeedCol = -2;
                    producedObjectsCount = 3;
                    break;
                case ObjectType.Stealth:
                    producedObjectSpeedRow = 2;
                    producedObjectSpeedCol = 0;
                    producedObjectsCount = 1;
                    break;
                case ObjectType.Player:
                    producedObjectType = ObjectType.Shell;
                    producedObjectSpeedRow = 0;
                    producedObjectSpeedCol = 2;
                    producedObjectsCount = 1;
                    break;
            }

            Coordinate producedObjectSpeed;
            GameObject producedObject;

            for (int shot = 0; shot < producedObjectsCount; shot++)
            {
                producedObjectSpeed = new Coordinate(producedObjectSpeedRow, producedObjectSpeedCol);
                producedObject = objectFactory.ProduceObject(producedObjectType, shootingPoint, producedObjectSpeed);

                this.producedObjects.Add(producedObject);

                producedObjectSpeedCol++;
            }
        }

        private void ProduceRandomEnemy()
        {
            Array objectTypeValues = Enum.GetValues(typeof(ObjectType));
            ObjectType producedObjectType = (ObjectType)objectTypeValues.GetValue(this.randomGenerator.Next(1, objectTypeValues.Length - 2));

            int producedObjectSpeedRow = 0;
            int producedObjectSpeedCol = this.randomGenerator.Next(1, 3) * -1;
            int producedObjectPositionRow = 0;
            int producedObjectPositionCol = ConsoleUI.CanvasColumns - 1;

            switch (producedObjectType)
            {
                case ObjectType.Battlecruiser:
                case ObjectType.Carrier:
                    producedObjectPositionRow = this.randomGenerator.Next(0, ConsoleUI.CanvasRows);
                    break;
                case ObjectType.Dragon:
                    producedObjectPositionRow = ConsoleUI.CanvasRows - ConsoleUI.DragonBody.GetLength(1);
                    break;
                case ObjectType.Stealth:
                    producedObjectPositionRow = 0;
                    break;
            }

            Coordinate producedObjectPosition = new Coordinate(producedObjectPositionRow, producedObjectPositionCol);
            Coordinate producedObjectSpeed = new Coordinate(producedObjectSpeedRow, producedObjectSpeedCol);

            GameObject producedObject = objectFactory.ProduceObject(producedObjectType, producedObjectPosition, producedObjectSpeed);
            this.AddGameObject(producedObject);
        }

        private void seedGameObjects()
        {
            this.AddGameObject(objectFactory.ProduceObject(ObjectType.Stealth, new Coordinate(0, 199), new Coordinate(0, -1)));
            this.AddGameObject(objectFactory.ProduceObject(ObjectType.Dragon, new Coordinate(20, 199), new Coordinate(0, -1)));
            this.AddGameObject(objectFactory.ProduceObject(ObjectType.Battlecruiser, new Coordinate(10, 199), new Coordinate(0, -1)));
            this.AddGameObject(objectFactory.ProduceObject(ObjectType.Carrier, new Coordinate(15, 199), new Coordinate(0, -1)));
        }
    }
}