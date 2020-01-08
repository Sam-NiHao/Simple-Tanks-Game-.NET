using System.Drawing;

namespace Tanks
{
    class Star
    {
        StarImage starImg = new StarImage();

        Image img;

        public Image Img
        {
            get { return img; }
        }

        int coordinateX, coordinateY;

        public int CoordinateX
        {
            get { return coordinateX; }
        }

        public int CoordinateY
        {
            get { return coordinateY; }
        }

        public Star(int starCoordinateX, int starCoordinateY)
        {
            img = starImg.StarImg;
            coordinateX = starCoordinateX;
            coordinateY = starCoordinateY;
        }
    }
}
