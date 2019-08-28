using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILudo
{
    class LudoBoardField
    {
        private Point point;
        private LudoHelper.type normal;

        public LudoHelper.type type { get; set; }

        public Point location { get; set; }

        public LudoBoardField(Point location, LudoHelper.type type)
        {
            this.location = location;
            this.type = type;
        }

      
    }
}
