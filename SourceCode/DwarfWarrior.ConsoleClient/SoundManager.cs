namespace DwarfWarrior.ConsoleClient
{
    using System.Media;

    public static class SoundManager
    {
        public static void PlayGameLoop()
        {
            SoundPlayer sound = new SoundPlayer(@"..\..\Sounds\GameLoop.wav");
            sound.PlayLooping();
        }
    }
}