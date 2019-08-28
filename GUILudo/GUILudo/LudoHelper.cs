using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILudo
{
    class LudoHelper
    {
        public enum state
        {
            ude,
            move,
            zone
        };

        public enum color
        {
            green,
            blue,
            yellow,
            red
        };

        public enum type
        {
            normal,
            star,
            globe,
            greenstart,
            greengoal,
            bluestart,
            bluegoal,
            yellowstart,
            yellowgoal,
            redstart,
            redgoal

        };
    }
}
