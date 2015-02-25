namespace DwarfWarrior.ConsoleClient
{
    using System;

    public static class ConsoleUI
    {
        public const string GameTitle = "Dwarf Warrior";
        public const int CanvasRows = 80;
        public const int CanvasColumns = 200;
        public const ConsoleColor PlayerColor = ConsoleColor.Cyan;
        public const ConsoleColor BattlecruiserColor = ConsoleColor.Magenta;
        public const ConsoleColor CarrierColor = ConsoleColor.Yellow;
        public const ConsoleColor DragonColor = ConsoleColor.Yellow;
        public const ConsoleColor StealtColor = ConsoleColor.Blue;
        public const ConsoleColor ShellColor = ConsoleColor.Green;
        public const ConsoleColor PalletColor = ConsoleColor.Red;
        public static readonly char[,] PlayerBody = 
        {
            {'>', '\\', '-', '-', '(', '@', ')', '-', '\\', ' '},
            {'>', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '>'},
            {'>', '/', '-', '-', '-', '-', '-', '-', '/', ' '}
        };
        public static readonly char[,] BattlecruiserBody = 
        {
            { ' ', '/', '^', '^', '^', '^', '^', '/' },
            { '(', ' ', '|', ' ', '|', ' ', '|', ' ' },
            { ' ', '\\', 'v', 'v', 'v', 'v', 'v', '\\' },
        };
        public static readonly char[,] CarrierBody = 
        {
            { ' ', '/', '\\', '/', '\\', '/', '\\', ' ' },
            { '(', 'S', 'S', 'S', 'S', 'S', 'S', ')' },
            { ' ', '\\', '/', '\\', '/', '\\', '/', ' ' },
        };
        public static readonly char[,] DragonBody =
        {
            { '/', 'o', 'o', 'o', '\\' }, 
            { ':', ' ', ' ', ' ', ':' }, 
            { '\\', 'V', 'V', 'V', '/' } 
        };
        public static readonly char[,] StealthBody = { { '(', '-', 'o', '-', ')' } };
        public static readonly char[,] ShellBody = { { '~' } };
        public static readonly char[,] PelletBody = { { '*' } };

        public static void InintGameCanvas()
        {
            Console.Title = ConsoleUI.GameTitle;

            Console.BufferHeight = Console.WindowHeight = ConsoleUI.CanvasRows + 2;
            Console.BufferWidth = Console.WindowWidth = ConsoleUI.CanvasColumns + 1;
        }
    }
}