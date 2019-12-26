using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Addetion_classes
{
    class DestroyedTankImage
    {
        Image destroyTank = Properties.Resources.DestroyedTank;

        public Image DestroyTank { get => destroyTank; set => destroyTank = value; }
    }
}
