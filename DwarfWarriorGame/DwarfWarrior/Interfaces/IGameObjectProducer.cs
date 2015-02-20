namespace DwarfWarrior.Interfaces
{
    public interface IGameObjectProducer
    {
        GameObject ProduceObject(ObjectType type, int positionRow, int positionCol, int speedRow, int speedCol);
    }
}
