using System.Drawing;

namespace Tanks
{
    class MissileImage
    {
        Image missileImageUp = Properties.Resources.MissileUp;
        Image missileImageDown = Properties.Resources.MissileDown;
        Image missileImageLeft = Properties.Resources.MissileLeft;
        Image missileImageRight = Properties.Resources.MissileRight;

        public Image MissileImageUp { get => missileImageUp; }
        public Image MissileImageDown { get => missileImageDown; }
        public Image MissileImageLeft { get => missileImageLeft; }
        public Image MissileImageRight { get => missileImageRight; }
    }
}
