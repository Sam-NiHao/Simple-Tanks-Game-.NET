using System.Drawing;

namespace Tanks.Addetion_classes
{
    class DestroyedTankImage
    {
        Image destroyTank = Properties.Resources.DestroyedTank;

        public Image DestroyTank { get => destroyTank; set => destroyTank = value; }
    }
}
