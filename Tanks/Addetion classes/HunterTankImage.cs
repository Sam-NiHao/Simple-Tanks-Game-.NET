using System.Drawing;

namespace Tanks
{
    class HunterTankImage
    {
        Image hunterTankImageUp = Properties.Resources.HunterTankUp;
        Image hunterTankImageDown = Properties.Resources.HunterTankDown;
        Image hunterTankImageLeft = Properties.Resources.HunterTankLeft;
        Image hunterTankImageRight = Properties.Resources.HunterTankRight;

        public Image HunterTankImageUp { get => hunterTankImageUp; }
        public Image HunterTankImageDown { get => hunterTankImageDown; }
        public Image HunterTankImageLeft { get => hunterTankImageLeft; }
        public Image HunterTankImageRight { get => hunterTankImageRight; }
    }
}
