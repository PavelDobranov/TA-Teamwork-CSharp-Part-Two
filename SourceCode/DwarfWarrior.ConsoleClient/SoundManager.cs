namespace DwarfWarrior.ConsoleClient
{
    using System;
    using System.IO;
    using System.Media;
    using System.Security;
    using System.Windows.Forms;

    public static class SoundManager
    {
        private const string GameSoundPath = @"..\..\Sounds\GameLoop.wav";
        private static bool musicAvalible = true;

        public static void PlayGameLoop()
        {
            try
            {
                SoundPlayer sound = new SoundPlayer(GameSoundPath);

                if (musicAvalible)
                {
                    sound.PlayLooping();
                }
            }
            catch (TypeInitializationException)
            {
                MessageBox.Show("The sound file is corrupted (is not in the correct format)! Sound will be disabled!", "Sound file is corrupted?!");
                musicAvalible = false;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                musicAvalible = false;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                musicAvalible = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(string.Format("The file {0} was not found! Sound will be disabled!", GameSoundPath), "File not found!");
                musicAvalible = false;
            }
            catch (FileLoadException)
            {
                MessageBox.Show(string.Format("The file {0} cannot be loaded! The sound will be disabled!", GameSoundPath), "File cannot be loaded!");
                musicAvalible = false;
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0} ! The sound will be disabled!", GameSoundPath), "Input Output error!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will be disabled!", GameSoundPath), "You don't have permission to access this file");
            }
            catch (SecurityException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will be disabled!", GameSoundPath), "You don't have permission to access this file");
            }
        }
    }
}