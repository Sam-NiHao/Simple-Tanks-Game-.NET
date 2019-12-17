using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class WallImage
    {
        Image wallImg = Properties.Resources.wall;

        public Image WallImg
        {
            get { return wallImg; }
            set { wallImg = value; }
        }
    }
}
