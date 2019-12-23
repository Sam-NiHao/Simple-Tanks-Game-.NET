using System;
using Tanks.Addetion_classes;

namespace Tanks
{
    class EnemyTank : AbstractTank
    {
        EnemyTankImage tankImg = new EnemyTankImage();

        public EnemyTank(int fieldSize, int x, int y)
        {
            FieldSize = fieldSize;

            ChooseDiractionForTanks();

            ChooseImageDiraction();

            CoordinateX = x;
            CoordinateY = y;
        }

        public override void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                Img = tankImg.TankImageRight;
            }
            if (DirectX == -1)
            {
                Img = tankImg.TankImageLeft;
            }
            if (DirectY == 1)
            {
                Img = tankImg.TankImageDown;
            }
            if (DirectY == -1)
            {
                Img = tankImg.TankImageUp;
            }
        }
    }
}
