using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class Wall
    {
        WallImage wallImg = new WallImage();
        Image img;
        int coordinateX, coordinateY;

        public Wall()
        {
            img = wallImg.WallImg;
        }
        public int CoordinateX
        {
            get { return coordinateX; }
        }

        public int CoordinateY
        {
            get { return coordinateY; }
        } 

        public Image Img
        {
            get { return img; }
        }
    }
}
