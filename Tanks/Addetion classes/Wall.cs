using System.Drawing;

namespace Tanks
{
    class Wall
    {
        WallImage wallImg = new WallImage();

        Image img;
        public Image Img
        {
            get { return img; }
        }

        public Wall()
        {
            img = wallImg.WallImg;
        } 
    }
}
