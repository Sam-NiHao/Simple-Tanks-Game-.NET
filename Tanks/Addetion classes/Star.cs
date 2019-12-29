﻿using System.Drawing;

namespace Tanks.Addetion_classes
{
    class Star
    {
        StarImage starImg = new StarImage();
        Image img;

        int coordinateX, coordinateY;

        public Star(int x, int y)
        {
            img = starImg.StarImg;
            coordinateX = x;
            coordinateY = y;
        }

        public Image Img
        {
            get { return img; }
        }

        public int CoordinateX
        {
            get { return coordinateX; }
        }

        public int CoordinateY
        {
            get { return coordinateY; }
        }
    }
}
