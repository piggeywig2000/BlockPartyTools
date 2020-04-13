using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockPartyTools
{
    class EventJson<T>
    {
        public string name { get; set; }
        public EventJsonArgs<T>[] args { get; set; }

        public bool Validate()
        {
            if (args == null) return false;
            if (args.Length != 1) return false;
            if (args[0].data == null) return false;

            return true;
        }
    }

    class EventJsonArgs<T>
    {
        public string type { get; set; }
        public EventJsonArgs<T>[] args { get; set; }
        public T data { get; set; }
        public string ackRequested { get; set; }
    }

    class LoadSongData
    {
        public string server { get; set; }
        public string name { get; set; }
        public string file { get; set; }
        public string soundcloud { get; set; }
    }

    class NarrationData
    {
        public string server { get; set; }
        public string type { get; set; }
        public string file { get; set; }
    }

    class ControlData
    {
        public string server { get; set; }
        public int play { get; set; }
    }

    enum ClayColor
    {
        White,
        Orange,
        Magenta,
        LightBlue,
        Yellow,
        Lime,
        Pink,
        Grey,
        LightGrey,
        Cyan,
        Purple,
        Blue,
        Brown,
        Green,
        Red,
        Black
    }

    class ColorData
    {
        public string server { get; set; }
        public int colorid { get; set; }
    }

    class EndGameData
    {
        public string server { get; set; }
        public string doit { get; set; }
    }
}
