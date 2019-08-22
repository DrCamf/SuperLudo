using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace testarea
{
    class PlayPiece
    {
        public LudoHelper.color color { get; set; }

        public Point location { get; set; }
        public int locationBoard { get; set; }
        public LudoHelper.state state { get; set; }

        public string brikNr { get; set; }

        public bool inGoal { get; set; }

        public PlayPiece(LudoHelper.color color, int locationBoard, LudoHelper.state state, bool inGoal, string brikNr)
        {
            this.color = color;
            this.locationBoard = locationBoard;
            this.state = state;
            this.inGoal = false;
            this.brikNr = brikNr;

        }
    }
}
