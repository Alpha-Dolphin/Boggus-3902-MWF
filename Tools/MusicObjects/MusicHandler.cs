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
    public class MusicHandler
    {
        private Song CurrentSong;
        private float Volume;

        public void SelectSong(Song song)
        {
            this.CurrentSong = song;
        }
        public void Play()
        {
            MediaPlayer.Play(this.CurrentSong);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        public void ToggleMute()
        {
            MediaPlayer.IsMuted = !(MediaPlayer.IsMuted);
        }

        public bool IsMuted()
        {
            return (MediaPlayer.IsMuted);
        }
    }
}
