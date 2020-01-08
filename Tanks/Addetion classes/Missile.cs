using System.Drawing;

namespace Tanks
{
    class Missile
    {
        MissileImage missileImg = new MissileImage();
        internal MissileImage MissileImg { get => missileImg; }

        Image img;
        public Image Img { get => img; }

        int coordinateX, coordinateY, directX, directY;

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
        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }

        public Missile()
        {
            img = MissileImg.MissileImageDown;
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            int defaultCoordinate = -50;
            coordinateX = coordinateY = defaultCoordinate;
            DirectX = DirectY = 0;
        }

        public void Move()
        {
            byte missileSpeed = 4;

            ChooseImageDiraction();

            coordinateX += DirectX * missileSpeed;
            coordinateY += DirectY * missileSpeed;
        }

        public void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                img = missileImg.MissileImageRight;
            }

            if (DirectX == -1)
            {
                img = missileImg.MissileImageLeft;
            }

            if (DirectY == 1)
            {
                img = missileImg.MissileImageDown;
            }

            if (DirectY == -1)
            {
                img = missileImg.MissileImageUp;
            }
        }
    }
}
