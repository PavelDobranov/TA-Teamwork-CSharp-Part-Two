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


            var keyboard = new KeyboardController();
            var renderer = new ConsoleRenderer(ConsoleUIObjects.GameRows, ConsoleUIObjects.GameCols);
            var factory = new GameObjectsFactory();
            var player = factory.ProduceObject(ObjectType.Player, 10, 10, 0, 0) as Player;
            var engine = new Engine(keyboard, renderer, factory, player);
            engine.AddPlayer();

            //engine.AddGameObject(factory.ProduceObject(ObjectType.Battlecruiser, 0, ConsoleUIObjects.GameCols - 1, 0, -1));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Carrier, 4, ConsoleUIObjects.GameCols - 1, 0, -1));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Dragon, 8, ConsoleUIObjects.GameCols - 1, 0, -1));
            //engine.AddGameObject(factory.ProduceObject(ObjectType.Stealth, 12, ConsoleUIObjects.GameCols - 1, 0, -1));


            keyboard.OnUpPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Row > 0)
                {
                    engine.MovePlayerUp();
                }
            };

            keyboard.OnDownPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Row < ConsoleUIObjects.GameRows - player.BodyHeight)
                {
                    engine.MovePlayerDown();
                }
            };

            keyboard.OnLeftPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Col > 0)
                {
                    engine.MovePlayerLeft();
                }
            };

            keyboard.OnRightPressed += (sender, eventinfo) =>
            {
                if (player.TopLeftPosition.Col < ConsoleUIObjects.GameCols - player.BodyWidth)
                {
                    engine.MovePlayerRight();
                }
            };

            keyboard.OnActionPressed += (sender, eventinfo) =>
            {
                engine.PlayerShoot();
            };


            engine.Run();


        }
    }
}