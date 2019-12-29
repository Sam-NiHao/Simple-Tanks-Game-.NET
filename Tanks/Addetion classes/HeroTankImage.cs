using System.Drawing;

namespace Tanks.Addetion_classes
{
    class HeroTankImage
    {
        Image heroTankImageUp = Properties.Resources.HeroTankUp;
        Image heroTankImageDown = Properties.Resources.HeroTankDown;
        Image heroTankImageLeft = Properties.Resources.HeroTankLeft;
        Image heroTankImageRight = Properties.Resources.HeroTankRight;

        public Image HeroTankImageUp { get => heroTankImageUp; set => heroTankImageUp = value; }
        public Image HeroTankImageDown { get => heroTankImageDown; set => heroTankImageDown = value; }
        public Image HeroTankImageLeft { get => heroTankImageLeft; set => heroTankImageLeft = value; }
        public Image HeroTankImageRight { get => heroTankImageRight; set => heroTankImageRight = value; }
    }
}
