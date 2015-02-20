namespace DwarfWarrior
{
    using System;

    class Program
    {
        static void Main()
        {
            int rows = 25;
            int cols = 25;

            var renderer = new ConsoleRenderer(rows, cols);
            var factory = new GameObjectsFactory();
            var pesho = factory.ProduceObject(ObjectType.Dragon, 22, -1, 0, 0);

            renderer.AddToBuffer(pesho);
            renderer.RenderAll();
            Console.ReadLine();
        }
    }
}