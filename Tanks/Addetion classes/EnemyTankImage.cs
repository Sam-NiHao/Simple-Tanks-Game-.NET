using System.Drawing;

namespace Tanks
{
    class EnemyTankImage
    {
        Image tankImageUp = Properties.Resources.EnemyTankUp;
        Image tankImageDown = Properties.Resources.EnemyTankDown;
        Image tankImageLeft = Properties.Resources.EnemyTankLeft;
        Image tankImageRight = Properties.Resources.EnemyTankRight;

        public Image TankImageUp { get => tankImageUp; set => tankImageUp = value; }
        public Image TankImageDown { get => tankImageDown; set => tankImageDown = value; }
        public Image TankImageLeft { get => tankImageLeft; set => tankImageLeft = value; }
        public Image TankImageRight { get => tankImageRight; set => tankImageRight = value; }
    }
}
