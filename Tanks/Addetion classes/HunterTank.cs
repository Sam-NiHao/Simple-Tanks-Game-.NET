using System;

namespace Tanks
{
    class HunterTank : AbstractTank
    {
        HunterTankImage hunterTankImg = new HunterTankImage();

        public HunterTank(int fieldSize, int hunterTankCoordinateX, int hunterTankCoordinateY)
        {
            FieldSize = fieldSize;

            ChooseDiractionForTanks();

            ChooseImageDiraction();

            CoordinateX = hunterTankCoordinateX;
            CoordinateY = hunterTankCoordinateY;
        }

        public void Turn(int hunterTankCoordinateX, int hunterTankCoordinateY)
        {
            DirectX = DirectY = 0;

            if (CoordinateX > hunterTankCoordinateX)
            {
                DirectX = -1;
            }

            if (CoordinateX < hunterTankCoordinateX)
            {
                DirectX = 1;
            }

            if (CoordinateY > hunterTankCoordinateY)
            {
                DirectY = -1;
            }

            if (CoordinateY < hunterTankCoordinateY)
            {
                DirectY = 1;
            }

            CheckDirectionNotEqualZero();

            ChooseImageDiraction();
        }

        private void CheckDirectionNotEqualZero()
        {
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
        }

        public void Move(int hunterTankCoordinateX, int hunterTankCoordinateY)
        {
            int distanceBetweenTanksCoordinates = 80;

            CoordinateX += DirectX;
            CoordinateY += DirectY;

            if ((Math.IEEERemainder(CoordinateX, distanceBetweenTanksCoordinates) == 0) && (Math.IEEERemainder(CoordinateY, distanceBetweenTanksCoordinates) == 0)) // мы на перекрестке
            {
                Turn(hunterTankCoordinateX, hunterTankCoordinateY);
            }

            TeleportThroughFieldBorders();
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
