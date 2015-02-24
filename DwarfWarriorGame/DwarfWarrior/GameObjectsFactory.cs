namespace DwarfWarrior
{
    using System;

    using Interfaces;

    public class GameObjectsFactory : IGameObjectProducer
    {
        public GameObject ProduceObject(ObjectType type, int positionRow, int positionCol, int speedRow, int speedCol)
        {
            Coordinate objectPosition = new Coordinate(positionRow, positionCol);
            Coordinate objectSpeed = new Coordinate(speedRow, speedCol);

            switch (type)
            {
                case ObjectType.Player:
                    return new Player(objectPosition, objectSpeed, ConsoleUI.PlayerBody());
                case ObjectType.Battlecruiser:
                    return new Battlecruiser(objectPosition, objectSpeed, ConsoleUI.BattlecruiserBody());
                case ObjectType.Carrier:
                    return new Carrier(objectPosition, objectSpeed, ConsoleUI.CarrierBody());
                case ObjectType.Dragon:
                    return new Dragon(objectPosition, objectSpeed, ConsoleUI.DragonBody());
                case ObjectType.Stealth:
                    return new Stealth(objectPosition, objectSpeed, ConsoleUI.StealtBody());
                case ObjectType.Shell:
                    return new Shell(objectPosition, objectSpeed, ConsoleUI.ShellBody());
                case ObjectType.Pellet:
                    return new Pellet(objectPosition, objectSpeed, ConsoleUI.PalletBody());
                default:
                    throw new ArgumentException("Invalid game object type", "type");
            }
        }
    }
}