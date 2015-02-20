namespace DwarfWarrior.Interfaces
{
    public interface IRenderer
    {
        void AddToBuffer();

        void RenderAll();

        void ClearBuffer();
    }
}