namespace DwarfWarrior.Interfaces
{
    using DwarfWarrior.GameObjects;

    public interface IRenderer
    {
        void AddToBuffer(GameObject gameObject);

        void RenderAll();

        void ClearBuffer();
    }
}