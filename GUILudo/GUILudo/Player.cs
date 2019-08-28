﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILudo
{
    class Player
    {

        public bool isPieceOut { get; set; }
        public LudoHelper.color colorChoise { get; set; }
        public int playerNr { get; set; }
        public bool isHuman { get; set; }

        public Player(bool isPieceOut, LudoHelper.color colorChoise, bool isHuman, int playerNr)
        {

            this.isPieceOut = isPieceOut;
            this.colorChoise = colorChoise;
            this.isHuman = isHuman;
            this.playerNr = playerNr;
        }
    }
}
