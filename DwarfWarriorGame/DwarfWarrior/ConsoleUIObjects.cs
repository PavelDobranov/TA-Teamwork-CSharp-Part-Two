using System;

namespace GalacticNinja
{
    public static class ConsoleUIObjects
    {
        public static char[,] PlayerBody()
        {
            return new char[,]
            {
                { '>', '\\', '-', '-', '(', '@', ')', '-', '\\', ' ' },
                { '>', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '>' },
                { '>', '/', '-', '-', '-', '-', '-', '-', '/', ' ' },
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

        public static ConsoleColor PlayerColor()
        {
            return ConsoleColor.Cyan;
        }

        public static ConsoleColor BattlecruiserColor()
        {
            return ConsoleColor.Magenta;
        }

        public static ConsoleColor CarrierColor()
        {
            return ConsoleColor.Yellow;
        }

        public static ConsoleColor DragonColor()
        {
            return ConsoleColor.Yellow;
        }

        public static ConsoleColor StealtColor()
        {
            return ConsoleColor.Blue;
        }

        public static ConsoleColor ShellColor()
        {
            return ConsoleColor.Green;
        }

        public static ConsoleColor PalletColor()
        {
            return ConsoleColor.Red;
        }
    }
}