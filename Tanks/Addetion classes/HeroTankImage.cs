using System.Drawing;

namespace Tanks
{
    class HeroTankImage
    {
        Image heroTankImageUp = Properties.Resources.HeroTankUp;
        Image heroTankImageDown = Properties.Resources.HeroTankDown;
        Image heroTankImageLeft = Properties.Resources.HeroTankLeft;
        Image heroTankImageRight = Properties.Resources.HeroTankRight;

        public Image HeroTankImageUp { get => heroTankImageUp; }
        public Image HeroTankImageDown { get => heroTankImageDown; }
        public Image HeroTankImageLeft { get => heroTankImageLeft; }
        public Image HeroTankImageRight { get => heroTankImageRight; }
    }
}
