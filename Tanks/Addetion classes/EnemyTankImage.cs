using System.Drawing;

namespace Tanks
{
    class EnemyTankImage
    {
        Image tankImageUp = Properties.Resources.EnemyTankUp;
        Image tankImageDown = Properties.Resources.EnemyTankDown;
        Image tankImageLeft = Properties.Resources.EnemyTankLeft;
        Image tankImageRight = Properties.Resources.EnemyTankRight;

        public Image TankImageUp { get => tankImageUp; }
        public Image TankImageDown { get => tankImageDown; }
        public Image TankImageLeft { get => tankImageLeft; }
        public Image TankImageRight { get => tankImageRight; }
    }
}
