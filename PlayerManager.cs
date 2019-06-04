using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WiiBalanceScale
{
    public class PlayerManager
    {
        private string resPath;
        private SoundPlayer primaryPlayer;
        private SoundPlayer secondaryPlayer;
        private SoundPlayer finalPlayer;

        public PlayerManager()
        {

            resPath = getResourcePath();

            primaryPlayer = initializePlayer(@"Beep-1.wav");
            secondaryPlayer = initializePlayer(@"Beep-2.wav");
            finalPlayer = initializePlayer(@"Beep-final.wav");

        }

        public void PlayPrimary()
        {
            primaryPlayer.Play();
        }

        public void PlaySecondary()
        {
            secondaryPlayer.Play();
        }

        public void PlayFinal()
        {
            finalPlayer.Play();
        }

        private string getResourcePath()
        {
            // getting root path
            string rootLocation = typeof(WiiBalanceStatokinesigram).Assembly.Location;
            return Path.GetDirectoryName(rootLocation);
        }

        private SoundPlayer initializePlayer(string fileName)
        {
            string fullPathToSound = Path.Combine(resPath, fileName);

            var player = new SoundPlayer();
            player.SoundLocation = fullPathToSound;
            player.LoadAsync();

            return player;
        }

    }
}
