using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class MissileImage
    {
        Image missileImageUp = Properties.Resources.MissileUp;
        Image missileImageDown = Properties.Resources.MissileDown;
        Image missileImageLeft = Properties.Resources.MissileLeft;
        Image missileImageRight = Properties.Resources.MissileRight;

        public Image MissileImageUp { get => missileImageUp; set => missileImageUp = value; }
        public Image MissileImageDown { get => missileImageDown; set => missileImageDown = value; }
        public Image MissileImageLeft { get => missileImageLeft; set => missileImageLeft = value; }
        public Image MissileImageRight { get => missileImageRight; set => missileImageRight = value; }
    }
}
