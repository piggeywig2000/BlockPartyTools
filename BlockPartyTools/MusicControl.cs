using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace BlockPartyTools
{
    class MusicControl
    {
        public bool IsPlaying { get; private set; } = true;

        public MusicControl(bool isPlayingInitially)
        {
            IsPlaying = isPlayingInitially;
        }

        public void Play()
        {
            if (IsPlaying) return;
            SendPlayPause();
            IsPlaying = true;
        }

        public void Pause()
        {
            if (!IsPlaying) return;
            SendPlayPause();
            IsPlaying = false;
        }

        private void SendPlayPause()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
        }
    }
}
