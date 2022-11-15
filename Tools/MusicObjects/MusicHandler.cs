using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer = Microsoft.Xna.Framework.Media.MediaPlayer;

namespace LOZ.Tools.MusicObjects
{
    internal class MusicHandler
    {
        private Song currentSong;

        public void SelectSong(Song song)
        {
            this.currentSong = song;
        }
        public void Play()
        {
            MediaPlayer.Play(this.currentSong);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }

        public void ToggleMute()
        {
            if (MediaPlayer.IsMuted)
            {
                MediaPlayer.IsMuted = false;

            }
            else
            {
                MediaPlayer.IsMuted = true;
            }
        }
    }
}
