using System.Drawing;

namespace Tanks.Addetion_classes
{
    class DestroyedTank
    {
        DestroyedTankImage destroyedTankImg = new DestroyedTankImage();
        Image img;
        int coordinateX, coordinateY;

        internal DestroyedTankImage DestroyedTankImg { get => destroyedTankImg; }
        public Image Img { get => img; }
        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }

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
