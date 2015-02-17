namespace DwarfWarrior.Interfaces
{
    public interface IRenderable
    {
        Coordinate TopLeftPosition { get; }
        
        char[,] Body { get; }
    }
}