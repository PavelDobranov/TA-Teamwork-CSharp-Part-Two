namespace DwarfWarrior.Interfaces
{
    public interface IRenderer
    {
        void AddToBuffer(GameObject obj);

        void RenderAll();

        void ClearBuffer();
    }
}