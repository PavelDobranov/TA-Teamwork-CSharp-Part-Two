namespace DwarfWarrior.ConsoleClient
{
    using System;

    using DwarfWarrior.Core.Interfaces;

    public class KeyboardController : IGameController
    {
        public event EventHandler OnUpPressed;
        public event EventHandler OnDownPressed;
        public event EventHandler OnLeftPressed;
        public event EventHandler OnRightPressed;
        public event EventHandler OnActionPressed;
        public event EventHandler OnEnterPressed;

        public void UserInput()
        {
            while (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Enter))
                {
                    if (this.OnEnterPressed != null)
                    {
                        this.OnEnterPressed(this, new EventArgs());
                    }
                }
            }
        }
    }
}