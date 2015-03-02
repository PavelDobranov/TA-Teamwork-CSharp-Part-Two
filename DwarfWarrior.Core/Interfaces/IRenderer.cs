namespace DwarfWarrior.Core.Interfaces
{
    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;

    public interface IRenderer
    {
        void AddToBuffer(GameObject gameObject);

        void RenderBuffer();

        void ClearBuffer();

        void RenderAtPosition(string text, Coordinate position);

        void RenderAtPosition(char[,] matrix, Coordinate position);
    }
}