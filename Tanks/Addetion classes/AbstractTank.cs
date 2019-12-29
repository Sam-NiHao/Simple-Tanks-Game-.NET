using System;
using System.Drawing;

namespace Tanks 
{
    abstract class AbstractTank : IMove, ITeleportation
    {
        public Image Img { get; set; }

        protected static Random random = new Random();

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
        public int FieldSize { get => fieldSize; set => fieldSize = value; }
        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }

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

        public virtual void Move()
        {
            CoordinateX += DirectX;
            CoordinateY += DirectY;

            if ((Math.IEEERemainder(CoordinateX, 80) == 0) && (Math.IEEERemainder(CoordinateY, 80) == 0)) // мы на перекрестке rename 80
            {
                Turn();
            }

            Teleport();
        }

        public void Teleport()
        {
            if (CoordinateX == -1)
            {
                CoordinateX = FieldSize - 1;
            }
            if (CoordinateX == FieldSize + 1)
            {
                CoordinateX = 1;
            }

            if (CoordinateY == -1)
            {
                CoordinateY = FieldSize - 1;
            }
            if (CoordinateY == FieldSize + 1)
            {
                CoordinateY = 1;
            }
        }

        public virtual void ReverseMove()
        {
            DirectX = -1 * DirectX;
            DirectY = -1 * DirectY;

            ChooseImageDiraction();
        }

        public virtual void Turn()
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
        public abstract void ChooseImageDiraction();
    }
}
