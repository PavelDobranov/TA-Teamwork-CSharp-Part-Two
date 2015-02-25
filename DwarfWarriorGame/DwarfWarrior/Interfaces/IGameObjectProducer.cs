namespace DwarfWarrior.Interfaces
{
    using DwarfWarrior.GameObjects;

    public interface IGameObjectProducer
    {
        GameObject ProduceObject(ObjectType type, Coordinate topLeftPosition, Coordinate speed);
    }
}
