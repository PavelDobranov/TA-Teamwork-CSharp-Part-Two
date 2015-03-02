namespace DwarfWarrior.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class SpaceUnitFactory : ISpaceUnitFactory
    {
        private const int EnemySpeedRow = 0;
        private const int MinEnemySpeedCol = 1;
        private const int MaxEnemySpeedCol = 3;
        private const int EnemiesStartEnumIndex = 1;

        private readonly int EnemiesEndEnumIndex;

        private int lastProducedRandomEnemyIndex;
        private Random randomGenerator;
        private Array objectTypeEnumIndices;

        public SpaceUnitFactory()
        {
            this.randomGenerator = new Random();
            this.objectTypeEnumIndices = Enum.GetValues(typeof(SpaceUnitType));
            this.EnemiesEndEnumIndex = this.objectTypeEnumIndices.Length - 1;
            this.lastProducedRandomEnemyIndex = 0;
        }

        public SpaceUnit ProduceSpaceUnit(SpaceUnitType type, Coordinate position, Coordinate speed, string collisionGroupString)
        {

            switch (type)
            {
                case SpaceUnitType.Banshee:
                    return new Banshee(position, speed, collisionGroupString, ConsoleUI.BansheeBody);
                case SpaceUnitType.Battlecruiser:
                    return new Battlecruiser(position, speed, collisionGroupString, ConsoleUI.BattlecruiserBody);
                case SpaceUnitType.Carrier:
                    return new Carrier(position, speed, collisionGroupString, ConsoleUI.CarrierBody);
                case SpaceUnitType.Dragon:
                    return new Dragon(position, speed, collisionGroupString, ConsoleUI.DragonBody);
                case SpaceUnitType.Stealth:
                    return new Stealth(position, speed, collisionGroupString, ConsoleUI.StealthBody);
                case SpaceUnitType.Scout:
                    return new Stealth(position, speed, collisionGroupString, ConsoleUI.ScoutBody);
                case SpaceUnitType.Shell:
                    if (collisionGroupString == "enemy")
                    {
                        return new Shell(position, speed, collisionGroupString, ConsoleUI.EnemyShellBody);
                    }
                    else
                    {
                        return new Shell(position, speed, collisionGroupString, ConsoleUI.PlayerShellBody);
                    }
                default:
                    throw new ArgumentException("Invalid space unit type", "type");
            }
        }

        public SpaceUnit ProduceRandomSpaceUnit(string collisionGroupString)
        {
            int enemyIndex;

            do
            {
                enemyIndex = GenerateRandomEnemyIndex();
            }
            while (enemyIndex == this.lastProducedRandomEnemyIndex);

            this.lastProducedRandomEnemyIndex = enemyIndex;

            SpaceUnitType enemyType = (SpaceUnitType)this.objectTypeEnumIndices.GetValue(enemyIndex);
            Coordinate enemyPosition = this.GenerateEnemyPosition(enemyType);
            Coordinate enemySpeed = this.GenerateEnemySpeed();

            return this.ProduceSpaceUnit(enemyType, enemyPosition, enemySpeed, collisionGroupString);
        }

        public List<SpaceUnit> ProduceShellsFrom(Spaceship spaceship)
        {
            List<SpaceUnit> producedShells = new List<SpaceUnit>();
            Coordinate shootingPoint = spaceship.GetShootingPoint();
            Coordinate shellSpeed = new Coordinate();
            string shellCollisionGroup = spaceship.CollisionGroupString == "player" ? "player" : "enemy";
            int shellsCount = 1;

            switch (spaceship.Type)
            {
                case SpaceUnitType.Banshee:
                    shellSpeed.Col = 5;
                    break;
                case SpaceUnitType.Battlecruiser:
                case SpaceUnitType.Carrier:
                case SpaceUnitType.Scout:
                    shellSpeed.Row = 0;
                    shellSpeed.Col = spaceship.Speed.Col * 2;
                    break;
                case SpaceUnitType.Stealth:
                    shellSpeed.Row -= spaceship.Speed.Col * 2;
                    shellSpeed.Col = 0;
                    break;
                case SpaceUnitType.Dragon:
                    shellSpeed.Row += spaceship.Speed.Col * 2;
                    shellSpeed.Col = -1;
                    shellsCount = 3;
                    break;
            }

            for (int shell = 0; shell < shellsCount; shell++)
            {
                producedShells.Add(this.ProduceSpaceUnit(SpaceUnitType.Shell, shootingPoint, shellSpeed, shellCollisionGroup));

                shellSpeed.Col++;
            }

            return producedShells;
        }

        private int GenerateRandomEnemyIndex()
        {
            return this.randomGenerator.Next(SpaceUnitFactory.EnemiesStartEnumIndex, this.EnemiesEndEnumIndex);
        }

        private Coordinate GenerateEnemyPosition(SpaceUnitType enemyType)
        {
            int enemyPositionRow = 0;
            int enemyPositionCol = ConsoleUI.CanvasCols - 1;

            switch (enemyType)
            {
                case SpaceUnitType.Battlecruiser:
                case SpaceUnitType.Carrier:
                case SpaceUnitType.Scout:
                    enemyPositionRow = this.randomGenerator.Next(ConsoleUI.FlyingShipsMinPositionRow, ConsoleUI.FlyingShipsMaxPositionRow);
                    break;
                case SpaceUnitType.Dragon:
                    enemyPositionRow = ConsoleUI.DragonPositionRow;
                    break;
                case SpaceUnitType.Stealth:
                    enemyPositionRow = ConsoleUI.StealthPositionRow;
                    break;
            }

            return new Coordinate(enemyPositionRow, enemyPositionCol);
        }

        private Coordinate GenerateEnemySpeed()
        {
            int enemySpeedCol = this.randomGenerator.Next(SpaceUnitFactory.MinEnemySpeedCol, SpaceUnitFactory.MaxEnemySpeedCol) * -1;

            return new Coordinate(SpaceUnitFactory.EnemySpeedRow, enemySpeedCol);
        }
    }
}