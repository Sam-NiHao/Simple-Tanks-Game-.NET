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

        public Wall()
        {
            img = wallImg.WallImg;
        }

        public Image Img
        {
            get { return img; }
        }
    }
}
