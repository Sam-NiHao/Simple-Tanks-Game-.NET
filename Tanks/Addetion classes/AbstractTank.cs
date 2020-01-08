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
        internal int FieldSize { get => fieldSize; set => fieldSize = value; }
        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }

        public void ChooseDiractionForTanks()
        {
            if (random.Next(0, 5000) < 2500)
            {
                SetDirectXDirectY();
            }
            else
            {
                SetDirectYDirectX();
            }
        }

        private void SetDirectYDirectX()
        {
            DirectY = 0;

            while (DirectX == 0)
            {
                DirectX = random.Next(-1, 2);
            }
        }

        private void SetDirectXDirectY()
        {
            DirectX = 0;

            while (DirectY == 0)
            {
                DirectY = random.Next(-1, 2);
            }
        }

        public virtual void Move()
        {
            int cornerDistance = 80;

            CoordinateX += DirectX;
            CoordinateY += DirectY;

            if ((Math.IEEERemainder(CoordinateX, cornerDistance) == 0) && (Math.IEEERemainder(CoordinateY, cornerDistance) == 0)) // мы на перекрестке
            {
                Turn();
            }

            TeleportThroughFieldBorders();
        }

        public void TeleportThroughFieldBorders()
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
                CheckDirectY();
            }
            else // далее будем двигатся по горизонтали
            {
                CheckDirectX();
            }

            ChooseImageDiraction();
        }

        private void CheckDirectX()
        {
            if (DirectX == 0)
            {
                SetDirectYDirectX();
            }
        }

        private void CheckDirectY()
        {
            if (DirectY == 0)
            {
                SetDirectXDirectY();
            }
        }

        public abstract void ChooseImageDiraction();
    }
}
