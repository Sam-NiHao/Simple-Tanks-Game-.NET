using System.Drawing;

namespace Tanks.Addetion_classes
{
    class HunterTankImage
    {
        Image hunterTankImageUp = Properties.Resources.HunterTankUp;
        Image hunterTankImageDown = Properties.Resources.HunterTankDown;
        Image hunterTankImageLeft = Properties.Resources.HunterTankLeft;
        Image hunterTankImageRight = Properties.Resources.HunterTankRight;

        public Image HunterTankImageUp { get => hunterTankImageUp; set => hunterTankImageUp = value; }
        public Image HunterTankImageDown { get => hunterTankImageDown; set => hunterTankImageDown = value; }
        public Image HunterTankImageLeft { get => hunterTankImageLeft; set => hunterTankImageLeft = value; }
        public Image HunterTankImageRight { get => hunterTankImageRight; set => hunterTankImageRight = value; }
    }
}
