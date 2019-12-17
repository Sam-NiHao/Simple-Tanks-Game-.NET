using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace Tanks
{
    class EnemyTankImage
    {
        Image tankImageUp = Properties.Resources.tankUp;
        Image tankImageDown = Properties.Resources.tankDown;
        Image tankImageLeft = Properties.Resources.tankLeft;
        Image tankImageRight = Properties.Resources.tankRight;

        public Image TankImageUp { get => tankImageUp; set => tankImageUp = value; }
        public Image TankImageDown { get => tankImageDown; set => tankImageDown = value; }
        public Image TankImageLeft { get => tankImageLeft; set => tankImageLeft = value; }
        public Image TankImageRight { get => tankImageRight; set => tankImageRight = value; }
    }
}
