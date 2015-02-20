namespace DwarfWarrior
{
    using System;

    class Program
    {
        static void Main()
        {
            //int rows = 50;
            //int cols = 50;

            //var renderer = new ConsoleRenderer(rows, cols);
            //var factory = new GameObjectsFactory();
            //var pesho = factory.ProduceObject(ObjectType.Dragon, 22, 15, 0, 0);

            //renderer.AddToBuffer(pesho);
            //renderer.RenderAll();
            //Console.ReadLine();

            var Engine = new Engine();
            var factory = new GameObjectsFactory();
            Engine.AddGameObject(factory.ProduceObject(ObjectType.Battlecruiser, 0, 50, 0, -1));
            Engine.AddGameObject(factory.ProduceObject(ObjectType.Carrier, 5, 50, 0, -1));
            Engine.AddGameObject(factory.ProduceObject(ObjectType.Dragon, 10, 60, 0, -1));
            Engine.AddGameObject(factory.ProduceObject(ObjectType.Stealth, 20, 70, 0, -1));

            Engine.Run();
            Console.ReadLine();
        }
    }
}