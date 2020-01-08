using System.Drawing;

namespace Tanks
{
    class DestroyedTank
    {
        DestroyedTankImage destroyedTankImg = new DestroyedTankImage();

        Image img;
        public Image Img { get => img; }

        int coordinateX, coordinateY;
        public int CoordinateX { get => coordinateX; }
        public int CoordinateY { get => coordinateY; }

        public DestroyedTank(int x, int y)
        {
            coordinateX = x;
            coordinateY = y;

            img = destroyedTankImg.DestroyTank;
        }

        public void Fire()
        {
            img = destroyedTankImg.DestroyTank;
        }
    }
}
