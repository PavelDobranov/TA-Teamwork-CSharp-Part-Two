namespace DwarfWarrior
{
    using System;

    public static class ConsoleUIObjects
    {
        public const int GameRows = 20;
        public const int GameCols = 50;
        public const int GameSpeed = 100;

        public const ConsoleColor PlayerColor = ConsoleColor.Cyan;

        public const ConsoleColor BattlecruiserColor = ConsoleColor.Magenta;

        public const ConsoleColor CarrierColor = ConsoleColor.Yellow;

        public const ConsoleColor DragonColor = ConsoleColor.Yellow;

        public const ConsoleColor StealtColor = ConsoleColor.Blue;

        public const ConsoleColor ShellColor = ConsoleColor.Green;

        public const ConsoleColor PalletColor = ConsoleColor.Red;

        
        public static char[,] PlayerBody()
        {
            return new char[,]
            {
                {'>', '\\', '-', '-', '(', '@', ')', '-', '\\', ' '},
                {'>', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '>'},
                {'>', '/', '-', '-', '-', '-', '-', '-', '/', ' '}
            };
        }

        public static char[,] BattlecruiserBody()
        {
            return new char[,]
            {
                { ' ', '/', '^', '^', '^', '^', '^', '/' },
                { '(', ' ', '|', ' ', '|', ' ', '|', ' ' },
                { ' ', '\\', 'v', 'v', 'v', 'v', 'v', '\\' },
            };
        }

        public static char[,] CarrierBody()
        {
            return new char[,]
            {
                { ' ', '/', '\\', '/', '\\', '/', '\\', ' ' },
                { '(', 'S', 'S', 'S', 'S', 'S', 'S', ')' },
                { ' ', '\\', '/', '\\', '/', '\\', '/', ' ' },
            };
        }

        public static char[,] DragonBody()
        {
            return new char[,]
            {
                { '/', 'o', 'o', 'o', '\\' }, 
                { ':', ' ', ' ', ' ', ':' }, 
                { '\\', 'V', 'V', 'V', '/' } 
            };
        }

        public static char[,] StealtBody()
        {
            return new char[,] { { '(', '-', 'o', '-', ')' } };
        }

        public static char[,] ShellBody()
        {
            return new char[,] { { '~' } };
        }

        public static char[,] PalletBody()
        {
            return new char[,] { { '*' } };
        }
    }
}