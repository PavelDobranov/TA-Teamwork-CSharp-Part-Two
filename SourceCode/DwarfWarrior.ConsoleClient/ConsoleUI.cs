namespace DwarfWarrior.ConsoleClient
{
    using System;

    public static class ConsoleUI
    {
        public const string GameTitle = "Dwarf Warrior";
        public const int CanvasRows = 50;
        public const int CanvasCols = 150;

        public const int BufferPositionRow = 8;
        public const int BufferPositionCol = 0;
        public const int BufferRows = 41;
        public const int BufferCols = 150;

        public const int CursorStepRow = 5;

        public const int LogoPositionRow = 0;
        public const int LogoPositionCol = 0;

        public const int HealthPositionRow = 2;
        public const int HealthPositionCol = 5;

        public const int ScorePositionRow = 2;
        public const int ScorePositionCol = 131;

        public const int BottomWallPositionRow = 49;
        public const int BottomWallPositionCol = 0;

        public const int HighScoreListPositionRow = 25;
        public const int HighScoreListPositionCol = 60;

        public const int MainMenuPositionRow = 12;
        public const int MainMenuPositionCol = 63;
        public const int MainMenuCursorPositionRow = 11;
        public const int MainMenuCursorPositionCol = 58;
        public static GameMode[] MainMenuItems = { GameMode.Play, GameMode.ControlsMenu, GameMode.HighScore, GameMode.Exit };

        public static int ConstrolsMenuPositionRow = 5;
        public static int ConstrolsMenuPositionCol = 32;
        public const int ControlsMenuCursorPositionRow = 4;
        public const int ControlsMenuCursorPositionCol = 57;
        public static GameMode[] ControlsMenuItems = { GameMode.Play, GameMode.MainMenu };

        public static int HighScoreMenuPositionRow = 5;
        public static int HighScoreMenuPositionCol = 58;
        public const int HighScoreMenuCursorPositionRow = 4;
        public const int HighScoreMenuCursorPositionCol = 58;
        public static GameMode[] HighScoreMenuItems = { GameMode.Play, GameMode.MainMenu };

        public static int GameOverMenuPositionRow = 5;
        public static int GameOverMenuPositionCol = 37;
        public const int GameOverMenuCursorPositionRow = 4;
        public const int GameOverMenuCursorPositionCol = 57;
        public static GameMode[] GameOverMenuItems = { GameMode.Play, GameMode.HighScore, GameMode.MainMenu };

        public static int HittedHighScorePositionRow = 10;
        public static int HittedHighScorePositionCol = 25;

        public static int PlayerNamePromptPositionRow = 29;
        public static int PlayerNamePromptPositionCol = 73;

        public const int PlayerInitPositionRow = CanvasRows / 2;
        public const int PlayerInitPositionCol = 0;
        public const int PlayerInitSpeedRow = 0;
        public const int PlayerInitSpeedCol = 0;
        public const int PlayerMinRow = 1;
        public const int PlayerMaxRow = 35;

        public const int StealthPositionRow = 0;
        public const int DragonPositionRow = 38;
        public const int FlyingShipsMinPositionRow = 2;
        public const int FlyingShipsMaxPositionRow = 30;

        public static char[,] LogoBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\Logo");
        public static char[,] CursorBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\Cursor");
        public static char[,] ScoreBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\Score");
        public static char[,] HealthBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\Health");
        public static char[,] BottomWallBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\BottomWall");

        public static char[,] MainMenuBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\MainMenu");
        public static char[,] ControlsMenuBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\ControlsMenu");
        public static char[,] HighScoreMenuBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\HighScoreMenu");
        public static char[,] HittedHighScoreBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\HittedHighScore");
        public static char[,] GameOverMenuBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\UI\GameOverMenu");

        public static char[,] BansheeBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Banshee");
        public static char[,] BattlecruiserBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Battlecruiser");
        public static char[,] CarrierBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Carrier");
        public static char[,] DragonBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Dragon");
        public static char[,] StealthBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Stealth");
        public static char[,] ScoutBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Scout");
        public static char[,] WalkirBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\Walkir");
        public static char[,] PlayerShellBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\PlayerShell");
        public static char[,] EnemyShellBody = FileManager.TextFileToCharMatrix(ResourcesPath + @"\SpaceUnits\EnemyShell");

        private const string ResourcesPath = @"..\..\AsciiImages";
    }
}