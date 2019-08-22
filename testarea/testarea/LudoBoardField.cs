using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace testarea
{
    class LudoBoardField
    {
        public LudoHelper.type type { get; set; }

        public Point location { get; set; }

        public LudoBoardField(Point location, LudoHelper.type type)
        {
            this.location = location;
            this.type = type;
        }

        

    }
}
