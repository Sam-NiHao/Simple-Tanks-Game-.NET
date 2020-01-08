using System.Drawing;

namespace Tanks
{
    class AwardImage
    {
        readonly Image awardImg = Properties.Resources.Award;

        public Image AwardImg
        {
            get { return awardImg; }
        }
    }
}
