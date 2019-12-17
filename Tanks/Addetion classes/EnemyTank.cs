using System;
using System.Drawing;
using Tanks.Interfaces;

namespace Tanks
{
    class EnemyTank : IMove, ITeleportation
    {
        EnemyTankImage tankImg = new EnemyTankImage();

        Image img;

        static Random random;

        int coordinateX, coordinateY, directX, directY, fieldSize;

        public int DirectX
        {
            get { return directX; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    directX = value;
                else
                {
                    directX = 0;
                }
            }
        }

        public int DirectY
        {
            get { return directY; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    directY = value;
                else
                {
                    directY = 0;
                }
            }
        }

        public int CoordinateX { get => coordinateX; }

        public int CoordinateY { get => coordinateY; }

        public Image Img { get => img; }

        public EnemyTank(int fieldSize, int x, int y)
        {
            this.fieldSize = fieldSize;

            random = new Random();

            //img = tankImg.TankImageUp;

            ChooseDiractionForTanks();

            ChooseImageDiraction();

            coordinateX = x;
            coordinateY = y;
        }

        public void ChooseDiractionForTanks()
        {
            //if (random.Next(0, 5000) < 2500)
            //{
            //    DirectX = 0;

            //    while (DirectY == 0)
            //    {
            //        DirectY = random.Next(-1, 2);
            //    }
            //}
            //else
            //{
            //    DirectY = 0;

            //    while (DirectX == 0)
            //    {
            //        DirectX = random.Next(-1, 2);
            //    }
            //}

            if (random.Next(5000) < 2500)
            {
                DirectY = 0;
            loop:
                DirectX = random.Next(-1, 2);
                if (DirectX == 0)
                {
                    goto loop;
                }  
            }
            else
            {
                DirectX = 0;
            loop:
                DirectY = random.Next(-1, 2);
                if (DirectY == 0)
                {
                    goto loop;
                }
            }
        }

        public void Move()
        {
            coordinateX += DirectX;
            coordinateY += DirectY;

            if ((Math.IEEERemainder(CoordinateX, 80) == 0) && (Math.IEEERemainder(CoordinateY, 80) == 0)) // мы на перекрестке
            {
                Turn();
            }
            Teleport();
        }

        public void Turn()
        {
            if (random.Next(0, 5000) < 2500) // далее будем двигатся по вертикали
            {
                if (DirectY == 0)
                {
                    DirectX = 0; // что бы двигаться по вертикали

                    while (DirectY == 0) // Что бы дальше двигаться по вертикали, нужно Y присвоить 1 или -1
                    {
                        DirectY = random.Next(-1, 2);
                    }
                }
            }
            else // далее будем двигатся по горизонтали
            {
                if (DirectX == 0)
                {
                    DirectY = 0;

                    while (DirectX == 0)
                    {
                        DirectX = random.Next(-1, 2);
                    }
                }
            }
            ChooseImageDiraction();
        }

        public void Teleport()
        {
            if (CoordinateX == -1)
            {
                coordinateX = fieldSize - 1;
            }
            if (CoordinateX == fieldSize + 1)
            {
                coordinateX = 1;
            }

            if (coordinateY == -1)
            {
                coordinateY = fieldSize - 1;
            }
            if (coordinateY == fieldSize + 1)
            {
                coordinateY = 1;
            }
        }

        public void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                img = tankImg.TankImageRight;
            }
            if (DirectX == -1)
            {
                img = tankImg.TankImageLeft;
            }
            if (DirectY == 1)
            {
                img = tankImg.TankImageDown;
            }
            if (DirectY == -1)
            {
                img = tankImg.TankImageUp;
            }
        }
    }
}
