using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class Missile
    {
        MissileImage missileImg = new MissileImage();
        Image img;

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

        public Image Img { get => img; }
        internal MissileImage MissileImg { get => missileImg; }
        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }
        public Missile()
        {
            img = MissileImg.MissileImageDown;
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            coordinateX = coordinateY = -50;
            DirectX = DirectY = 0;
        }

        public void Move()
        {
            ChooseImageDiraction();

            coordinateX += DirectX * 4;
            coordinateY += DirectY * 4;
        }

        public void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                img = MissileImg.MissileImageRight;
            }
            if (DirectX == -1)
            {
                img = MissileImg.MissileImageLeft;
            }
            if (DirectY == 1)
            {
                img = MissileImg.MissileImageDown;
            }
            if (DirectY == -1)
            {
                img = MissileImg.MissileImageUp;
            }
        }
    }
}
