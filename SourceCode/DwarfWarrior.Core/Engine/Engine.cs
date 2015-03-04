namespace DwarfWarrior.Core.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;

    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Interfaces;

    public class Engine
    {
        private const int SleepTimeInMs = 50;
        private const int SpawnEnemyMinTime = 2;
        private const int SpawnEnemyMaxTime = 8;

        private IGameController gameController;
        private IRenderer renderer;
        private ISpaceUnitFactory spaceUnitFactory;
        private List<GameObject> gameObjects;
        private List<SpaceUnit> spaceUnits;
        private List<SpaceUnit> producedSpaceUnits;
        private GameObject healthUi;
        private GameObject scoreUi;
        private Player player;
        private Random randomGenerator;
        private DateTime lastSpawnedEnemy;
        private int canvasRows;
        private int canvasCols;

        public Engine(IGameController gameController, IRenderer renderer, ISpaceUnitFactory spaceUnitFactory, int canvasRows, int canvasColumns)
        {
            this.gameController = gameController;
            this.renderer = renderer;
            this.spaceUnitFactory = spaceUnitFactory;
            this.gameObjects = new List<GameObject>();
            this.spaceUnits = new List<SpaceUnit>();
            this.producedSpaceUnits = new List<SpaceUnit>();
            this.healthUi = null;
            this.scoreUi = null;
            this.player = null;
            this.randomGenerator = new Random();
            this.lastSpawnedEnemy = DateTime.Now;
            this.canvasRows = canvasRows;
            this.canvasCols = canvasColumns;
        }

        public void AddPlayer(Player player)
        {
            this.player = player;
            this.AddGameObject(player.Spaceship);
        }

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject is SpaceUnit)
            {
                this.spaceUnits.Add(gameObject as SpaceUnit);
            }

            this.gameObjects.Add(gameObject);
        }

        public void AddHealthUI(GameObject healthUi)
        {
            this.healthUi = healthUi;
        }

        public void AddScoreUi(GameObject scoreUi)
        {
            this.scoreUi = scoreUi;
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
            this.renderer.RenderAtPosition(this.healthUi.Body, this.healthUi.TopLeftPosition);
            this.renderer.RenderAtPosition(this.scoreUi.Body, this.scoreUi.TopLeftPosition);

            while (true)
            {
                this.RenderGameObjects();

                this.SleepScreen();

                this.ClearBuffer();

                this.HandldeUserInput();

                this.HandleCollisions();

                this.OperateOnGameObjects();

                this.RemoveDestroyedGameObjects();

                this.SpawnEnemy();

                this.AddGameObjectsToBuffer();

                this.PrintPlayerInfo();

                if (this.player.Spaceship.IsDestroyed)
                {
                    this.ClearBuffer();
                    break;
                }
            }
        }

        private void AddGameObjectsToBuffer()
        {
            foreach (var gameObject in this.gameObjects)
            {
                this.renderer.AddToBuffer(gameObject);
            }
        }

        private void RenderGameObjects()
        {
            this.renderer.RenderBuffer();
        }

        private void PrintPlayerInfo()
        {
            int ValueRighShift = 5;

            Coordinate healthUiValuePosition = new Coordinate(this.healthUi.TopLeftPosition.Row + this.healthUi.BodyHeight, this.healthUi.TopLeftPosition.Col + ValueRighShift);
            Coordinate scoreUiValuePosition = new Coordinate(this.scoreUi.TopLeftPosition.Row + this.scoreUi.BodyHeight, this.scoreUi.TopLeftPosition.Col + ValueRighShift);

            this.renderer.RenderAtPosition(this.player.Spaceship.Health.ToString(), healthUiValuePosition);
            this.renderer.RenderAtPosition(this.player.Score.ToString(), scoreUiValuePosition);
        }

        private void ClearBuffer()
        {
            this.renderer.ClearBuffer();
        }

        private void SleepScreen()
        {
            Thread.Sleep(Engine.SleepTimeInMs);
        }

        private void HandldeUserInput()
        {
            this.gameController.UserInput();
        }

        private void HandleCollisions()
        {
            CollisionManager.HandleCollisions(this.spaceUnits);
        }

        private void OperateOnGameObjects()
        {
            foreach (var gameObject in this.spaceUnits)
            {
                gameObject.Update();

                if (gameObject is Spaceship && gameObject.CollisionGroupString == "enemy")
                {
                    Spaceship currentSpaceship = gameObject as Spaceship;

                    if (currentSpaceship.IsDestroyed)
                    {
                        int score = Math.Abs(currentSpaceship.Damage * currentSpaceship.Speed.Col);

                        this.player.AddScore(score);

                        this.producedSpaceUnits.AddRange((this.spaceUnitFactory.ProduceExplosionFrom(currentSpaceship)));
                    }

                    if (currentSpaceship.CanShootAt(this.player.Spaceship))
                    {
                        this.producedSpaceUnits.AddRange((this.spaceUnitFactory.ProduceShellsFrom(currentSpaceship)));
                    }
                }

                if (IsOutOfCanvas(gameObject))
                {
                    gameObject.IsDestroyed = true;
                }
            }

            this.AddProducedSpaceUnits();
        }

        private void AddProducedSpaceUnits()
        {
            this.gameObjects.AddRange(this.producedSpaceUnits);
            this.spaceUnits.AddRange(this.producedSpaceUnits);
            this.producedSpaceUnits.Clear();
        }

        private void RemoveDestroyedGameObjects()
        {
            this.gameObjects.RemoveAll(o => o.IsDestroyed);
            this.spaceUnits.RemoveAll(su => su.IsDestroyed);
        }

        private void SpawnEnemy()
        {
            TimeSpan timer = DateTime.Now - this.lastSpawnedEnemy;

            if (timer.Seconds == this.randomGenerator.Next(Engine.SpawnEnemyMinTime, Engine.SpawnEnemyMaxTime))
            {
                this.AddGameObject(this.spaceUnitFactory.ProduceRandomSpaceUnit("enemy"));
                this.lastSpawnedEnemy = DateTime.Now;
            }
        }

        private bool IsOutOfCanvas(GameObject gameObject)
        {
            return gameObject.TopLeftPosition.Col < -gameObject.BodyWidth ||
                   gameObject.TopLeftPosition.Row < -gameObject.BodyHeight ||
                   gameObject.TopLeftPosition.Col >= this.canvasCols ||
                   gameObject.TopLeftPosition.Row >= this.canvasRows;
        }
    }
}