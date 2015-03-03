namespace DwarfWarrior.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DwarfWarrior.Core.Engine;
    using DwarfWarrior.Core.GameObjects;
    using DwarfWarrior.Core.Helpers;
    using DwarfWarrior.Core.Interfaces;

    public class Game
    {
        private GameMode mode;
        private GameMode[] menuItems;
        private int menuItemIndex;
        private IGameController keyboard;
        private IRenderer renderer;
        ISpaceUnitFactory spaceUnitFactory;

        private GameObject gameLogo;
        private GameObject bottomWall;
        private GameObject cursor;
        private bool cursorMoved;
        private GameObject mainMenu;
        private GameObject controlsMenu;
        private GameObject highScoreMenu;
        private GameObject gameOverMenu;
        private GameObject hittedHighScore;

        private List<KeyValuePair<int, string>> highScore;
        private Engine gameEngine;
        private Player player;

        public Game()
        {
            this.mode = GameMode.MainMenu;
            this.menuItems = ConsoleUI.MainMenuItems;
            this.menuItemIndex = 0;
            this.cursorMoved = false;
            this.keyboard = new KeyboardController();
            this.renderer = new Renderer(ConsoleUI.BufferRows, ConsoleUI.BufferCols, new Coordinate(ConsoleUI.BufferPositionRow, ConsoleUI.BufferPositionCol));
            this.spaceUnitFactory = new SpaceUnitFactory();

            this.gameLogo = new GameObject(new Coordinate(ConsoleUI.LogoPositionRow, ConsoleUI.LogoPositionCol), ConsoleUI.LogoBody);
            this.bottomWall = new GameObject(new Coordinate(ConsoleUI.BottomWallPositionRow, ConsoleUI.BottomWallPositionCol), ConsoleUI.BottomWallBody);
            this.cursor = new GameObject(new Coordinate(ConsoleUI.MainMenuCursorPositionRow, ConsoleUI.MainMenuCursorPositionCol), ConsoleUI.CursorBody);
            this.mainMenu = new GameObject(new Coordinate(ConsoleUI.MainMenuPositionRow, ConsoleUI.MainMenuPositionCol), ConsoleUI.MainMenuBody);
            this.controlsMenu = new GameObject(new Coordinate(ConsoleUI.ConstrolsMenuPositionRow, ConsoleUI.ConstrolsMenuPositionCol), ConsoleUI.ControlsMenuBody);
            this.highScoreMenu = new GameObject(new Coordinate(ConsoleUI.HighScoreMenuPositionRow, ConsoleUI.HighScoreMenuPositionCol), ConsoleUI.HighScoreMenuBody);
            this.gameOverMenu = new GameObject(new Coordinate(ConsoleUI.GameOverMenuPositionRow, ConsoleUI.GameOverMenuPositionCol), ConsoleUI.GameOverMenuBody);
            this.hittedHighScore = new GameObject(new Coordinate(ConsoleUI.HittedHighScorePositionRow, ConsoleUI.HittedHighScorePositionCol), ConsoleUI.HittedHighScoreBody);

            this.highScore = FileManager.ParseHighScore();
            this.gameEngine = null;
            this.player = null;
        }

        public void Run()
        {
            this.InitConsoleCanvas();

            Task gameSoundLoop = new Task(() => SoundManager.PlayGameLoop());
            gameSoundLoop.Start();

            this.BindKeyboardResponse();

            this.PrintGameLogo();

            while (this.mode != GameMode.Exit)
            {
                switch (this.mode)
                {
                    case GameMode.MainMenu:
                        this.RunMainMenu();
                        break;
                    case GameMode.ControlsMenu:
                        this.RunControlsMenu();
                        break;
                    case GameMode.HighScore:
                        this.RunHighScoreMenu();
                        break;
                    case GameMode.GameOver:
                        this.RunGameOverMenu();
                        break;
                    case GameMode.Play:
                        this.Play();
                        break;
                }
            }
        }

        private void InitConsoleCanvas()
        {
            Console.Title = ConsoleUI.GameTitle;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = ConsoleUI.CanvasRows + 1;
            Console.BufferWidth = Console.WindowWidth = ConsoleUI.CanvasCols + 1;
        }

        private void RunMainMenu()
        {
            this.PrintGameLogo();

            this.mode = GameMode.MainMenu;
            this.menuItems = ConsoleUI.MainMenuItems;
            this.menuItemIndex = 0;

            this.cursor.TopLeftPosition = new Coordinate(ConsoleUI.MainMenuCursorPositionRow, ConsoleUI.MainMenuCursorPositionCol);

            this.PrintMainMenu();

            while (this.mode == GameMode.MainMenu)
            {
                keyboard.UserInput();

                if (this.cursorMoved)
                {
                    this.PrintMainMenu();
                    this.cursorMoved = !this.cursorMoved;
                }
            }
        }

        private void RunControlsMenu()
        {
            this.PrintGameLogo();

            this.mode = GameMode.ControlsMenu;
            this.menuItems = ConsoleUI.ControlsMenuItems;
            this.menuItemIndex = 0;

            this.cursor.TopLeftPosition = new Coordinate(ConsoleUI.ControlsMenuCursorPositionRow, ConsoleUI.ControlsMenuCursorPositionCol);

            this.PrintControlsMenu();

            while (this.mode == GameMode.ControlsMenu)
            {
                keyboard.UserInput();

                if (this.cursorMoved)
                {
                    this.PrintControlsMenu();
                    this.cursorMoved = !this.cursorMoved;
                }
            }
        }

        private void RunHighScoreMenu()
        {
            this.PrintGameLogo();

            this.mode = GameMode.HighScore;
            this.menuItems = ConsoleUI.HighScoreMenuItems;
            this.menuItemIndex = 0;

            this.cursor.TopLeftPosition = new Coordinate(ConsoleUI.HighScoreMenuCursorPositionRow, ConsoleUI.HighScoreMenuCursorPositionCol);

            this.PrintHighScoreMenu();

            while (this.mode == GameMode.HighScore)
            {
                keyboard.UserInput();

                if (this.cursorMoved)
                {
                    this.PrintHighScoreMenu();
                    this.cursorMoved = !this.cursorMoved;
                }
            }
        }

        private void RunGameOverMenu()
        {
            this.mode = GameMode.GameOver;

            if (this.player.Score > this.highScore[this.highScore.Count - 1].Key)
            {
                this.PrintHittedHighScore();
                this.SavePlayerHighScore();
            }

            this.menuItems = ConsoleUI.GameOverMenuItems;
            this.menuItemIndex = 0;

            this.cursor.TopLeftPosition = new Coordinate(ConsoleUI.GameOverMenuCursorPositionRow, ConsoleUI.GameOverMenuCursorPositionCol);

            this.PrintGameOverMenu();

            while (this.mode == GameMode.GameOver)
            {
                keyboard.UserInput();

                if (this.cursorMoved)
                {
                    this.PrintGameOverMenu();
                    this.cursorMoved = !this.cursorMoved;
                }
            }
        }

        private void SavePlayerHighScore()
        {
            int playerScoreIndex = 0;
            string playerName = string.Empty;

            for (int index = 0; index < this.highScore.Count; index++)
            {
                if (this.player.Score > this.highScore[index].Key)
                {
                    playerScoreIndex = index;


                    Console.CursorVisible = true;
                    Console.SetCursorPosition(ConsoleUI.PlayerNamePromptPositionCol, ConsoleUI.PlayerNamePromptPositionRow);
                    playerName = Console.ReadLine().ToUpper();
                    Console.CursorVisible = false;

                    break;
                }
            }

            this.highScore.Insert(playerScoreIndex, new KeyValuePair<int, string>(this.player.Score, playerName));
            this.highScore.RemoveAt(this.highScore.Count - 1);
            FileManager.SaveHighScore(this.highScore);
        }

        private void PrintGameLogo()
        {
            this.renderer.RenderAtPosition(this.gameLogo.Body, new Coordinate(ConsoleUI.LogoPositionRow, ConsoleUI.LogoPositionCol));
            this.renderer.RenderAtPosition(this.bottomWall.Body, new Coordinate(ConsoleUI.BottomWallPositionRow, ConsoleUI.BottomWallPositionCol));
        }

        private void PrintMainMenu()
        {
            this.renderer.AddToBuffer(this.mainMenu);
            this.renderer.AddToBuffer(this.cursor);
            this.renderer.RenderBuffer();
            this.renderer.ClearBuffer();
        }

        private void PrintControlsMenu()
        {
            this.renderer.AddToBuffer(this.controlsMenu);
            this.renderer.AddToBuffer(this.cursor);
            this.renderer.RenderBuffer();
            this.renderer.ClearBuffer();
        }

        private void PrintHighScoreMenu()
        {
            this.renderer.AddToBuffer(this.highScoreMenu);
            this.renderer.AddToBuffer(this.cursor);
            this.renderer.RenderBuffer();
            this.renderer.ClearBuffer();
            this.PrintHighScoreList();
        }

        private void PrintHittedHighScore()
        {
            this.renderer.AddToBuffer(this.hittedHighScore);
            this.renderer.RenderBuffer();
            this.renderer.ClearBuffer();
        }

        private void PrintHighScoreList()
        {
            int highScoreListRow = ConsoleUI.HighScoreListPositionRow;
            int highScoreListCol = ConsoleUI.HighScoreListPositionCol;

            int highScoreListPaddingCount = 30;
            char highScoreListPaddingPaddingSymbol = '.';
            int highScoreListPaddingRowStep = 2;

            foreach (var item in this.highScore)
            {
                this.renderer.RenderAtPosition(string.Format("{0} {1}", item.Value.PadRight(highScoreListPaddingCount, highScoreListPaddingPaddingSymbol), item.Key), new Coordinate(highScoreListRow, highScoreListCol));
                highScoreListRow += highScoreListPaddingRowStep;
            }
        }

        private void PrintGameOverMenu()
        {
            this.renderer.AddToBuffer(this.gameOverMenu);
            this.renderer.AddToBuffer(this.cursor);
            this.renderer.RenderBuffer();
            this.renderer.ClearBuffer();
        }

        private void Play()
        {
            this.PrintGameLogo();

            this.mode = GameMode.Play;

            SpaceUnitType playerSpaceshipType = SpaceUnitType.Banshee;
            Coordinate playerSpaceshipPosition = new Coordinate(ConsoleUI.PlayerInitPositionRow, ConsoleUI.PlayerInitPositionCol);
            Coordinate playerSpaceshipSpeed = new Coordinate(ConsoleUI.PlayerInitSpeedRow, ConsoleUI.PlayerInitSpeedCol);
            string playerSpacesheepCollisionGroup = "player";
            Spaceship playerSpaceship = this.spaceUnitFactory.ProduceSpaceUnit(playerSpaceshipType, playerSpaceshipPosition, playerSpaceshipSpeed, playerSpacesheepCollisionGroup) as Spaceship;
            this.player = new Player(playerSpaceship);

            GameObject healthUi = new GameObject(new Coordinate(ConsoleUI.HealthPositionRow, ConsoleUI.HealthPositionCol), ConsoleUI.HealthBody);
            GameObject scoreUi = new GameObject(new Coordinate(ConsoleUI.ScorePositionRow, ConsoleUI.ScorePositionCol), ConsoleUI.ScoreBody);

            this.gameEngine = new Engine(this.keyboard, this.renderer, this.spaceUnitFactory, ConsoleUI.CanvasRows - this.gameLogo.BodyHeight, ConsoleUI.CanvasCols);

            this.gameEngine.AddPlayer(this.player);
            this.gameEngine.AddHealthUI(healthUi);
            this.gameEngine.AddScoreUi(scoreUi);

            this.gameEngine.Run();

            this.mode = GameMode.GameOver;
        }

        private void BindKeyboardResponse()
        {
            this.keyboard.OnUpPressed += (sender, eventinfo) =>
            {
                if (this.mode == GameMode.Play && this.player.Spaceship.TopLeftPosition.Row > ConsoleUI.PlayerMinRow)
                {
                    this.gameEngine.MovePlayerUp();
                }

                if (this.mode != GameMode.Play && this.menuItemIndex > 0)
                {
                    this.cursor.TopLeftPosition -= new Coordinate(ConsoleUI.CursorStepRow, 0);
                    this.menuItemIndex--;
                    this.cursorMoved = true;
                }
            };

            this.keyboard.OnDownPressed += (sender, eventinfo) =>
            {
                if (this.mode == GameMode.Play && this.player.Spaceship.TopLeftPosition.Row < ConsoleUI.PlayerMaxRow)
                {
                    this.gameEngine.MovePlayerDown();
                }

                if (this.mode != GameMode.Play && this.menuItemIndex < this.menuItems.Length - 1)
                {
                    this.cursor.TopLeftPosition += new Coordinate(ConsoleUI.CursorStepRow, 0);
                    this.menuItemIndex++;
                    this.cursorMoved = true;
                }
            };

            this.keyboard.OnLeftPressed += (sender, eventinfo) =>
            {
                if (this.player.Spaceship.TopLeftPosition.Col > 0)
                {
                    this.gameEngine.MovePlayerLeft();
                }
            };

            this.keyboard.OnRightPressed += (sender, eventinfo) =>
            {
                if (this.player.Spaceship.TopLeftPosition.Col < ConsoleUI.CanvasCols - this.player.Spaceship.BodyWidth)
                {
                    this.gameEngine.MovePlayerRight();
                }
            };

            this.keyboard.OnActionPressed += (sender, eventinfo) =>
            {
                SpaceUnit shell = this.spaceUnitFactory.ProduceShellsFrom(this.player.Spaceship as Spaceship)[0];

                this.gameEngine.AddGameObject(shell);
            };

            this.keyboard.OnEnterPressed += (sender, eventinfo) =>
            {
                if (this.mode != GameMode.Play)
                {
                    this.mode = this.menuItems[menuItemIndex];
                }
            };
        }
    }
}
