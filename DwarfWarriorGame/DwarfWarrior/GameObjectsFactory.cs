namespace DwarfWarrior
{
    using System;

    using DwarfWarrior.ConsoleClient;
    using DwarfWarrior.GameObjects;
    using DwarfWarrior.Interfaces;

    public class GameObjectsFactory : IGameObjectProducer
    {
        public GameObject ProduceObject(ObjectType type, Coordinate topLeftPosition, Coordinate speed)
        {
            switch (type)
            {
                case ObjectType.Player:
                    return new Player(topLeftPosition, speed, ConsoleUI.PlayerBody);
                case ObjectType.Battlecruiser:
                    return new Battlecruiser(topLeftPosition, speed, ConsoleUI.BattlecruiserBody);
                case ObjectType.Carrier:
                    return new Carrier(topLeftPosition, speed, ConsoleUI.CarrierBody);
                case ObjectType.Dragon:
                    return new Dragon(topLeftPosition, speed, ConsoleUI.DragonBody);
                case ObjectType.Stealth:
                    return new Stealth(topLeftPosition, speed, ConsoleUI.StealthBody);
                case ObjectType.Shell:
                    return new Shell(topLeftPosition, speed, ConsoleUI.ShellBody);
                case ObjectType.Pellet:
                    return new Pellet(topLeftPosition, speed, ConsoleUI.PelletBody);
                default:
                    throw new ArgumentException("Invalid game object type", "type");
            }
        }
    }
}