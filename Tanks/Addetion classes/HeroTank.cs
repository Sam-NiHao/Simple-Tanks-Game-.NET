using System;
using System.Drawing;
using Tanks.Interfaces;

namespace Tanks.Addetion_classes
{
    class HeroTank : AbstractTank
    {
        HeroTankImage heroTankImg = new HeroTankImage();

        public HeroTank(int fieldSize, int x, int y) : base(fieldSize, x, y) { }

        public override void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                Img = heroTankImg.HeroTankImageUp;
            }
            if (DirectX == -1)
            {
                Img = heroTankImg.HeroTankImageLeft;
            }
            if (DirectY == 1)
            {
                Img = heroTankImg.HeroTankImageRight;
            }
            if (DirectY == -1)
            {
                Img = heroTankImg.HeroTankImageUp;
            }
        }
    }
}
