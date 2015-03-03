namespace DwarfWarrior.Core.Interfaces
{
    using DwarfWarrior.Core.Helpers;

    public interface IRenderable
    {
        Coordinate TopLeftPosition { get; }
        
        char[,] Body { get; }
    }
}