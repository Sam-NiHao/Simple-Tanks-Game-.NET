using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class HunterTank : AbstractTank
    {
        int heroTankCoordinateX, heroTankCoordinateY;
        HunterTankImage hunterTankImg = new HunterTankImage();

        public HunterTank(int fieldSize, int x, int y)
        {
            FieldSize = fieldSize;

            ChooseDiractionForTanks();

            ChooseImageDiraction();

            CoordinateX = x;
            CoordinateY = y;
        }

        public void Turn(int heroTankCoordinateX, int heroTankCoordinateY)
        {
            if (CoordinateX > heroTankCoordinateX)
            {
                DirectX = -1;
            }
            else
            {
                DirectX = 1;
            }

            if (CoordinateY > heroTankCoordinateY)
            {
                DirectY = -1;
            }
            else
            {
                DirectY = 1;
            }

            if (DirectX != 0 && DirectY != 0)
            {
                if (random.Next(5000) < 2500)
                {
                    DirectX = 0;
                }
                else
                {
                    DirectY = 0;
                }

            }

            ChooseImageDiraction();
        }

        public void Move(int heroTankCoordinateX, int heroTankCoordinateY)
        {
            this.heroTankCoordinateX = heroTankCoordinateX;
            this.heroTankCoordinateY = heroTankCoordinateY;

            CoordinateX += DirectX;
            CoordinateY += DirectY;

            if ((Math.IEEERemainder(CoordinateX, 80) == 0) && (Math.IEEERemainder(CoordinateY, 80) == 0)) // мы на перекрестке
            {
                Turn(heroTankCoordinateX, heroTankCoordinateY);
            }
            Teleport();
        }

        public override void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                Img = hunterTankImg.HunterTankImageRight;
            }
            if (DirectX == -1)
            {
                Img = hunterTankImg.HunterTankImageLeft;
            }
            if (DirectY == 1)
            {
                Img = hunterTankImg.HunterTankImageDown;
            }
            if (DirectY == -1)
            {
                Img = hunterTankImg.HunterTankImageUp;
            }
        }
    }
}
