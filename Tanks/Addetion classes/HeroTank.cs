namespace Tanks
{
    class HeroTank : AbstractTank
    {
        static HeroTank uniqueInstance;
        public static HeroTank SingeltonMethod()
        {
            if(uniqueInstance == null)
            {
                return new HeroTank();
            }
            return uniqueInstance;
        }

        HeroTankImage heroTankImg = new HeroTankImage();

        int directXTurn, directYTurn;

        public int DirectXTurn
        {
            get { return directXTurn; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    directXTurn = value;
                else
                {
                    directXTurn = 0;
                }
            }
        }
        public int DirectYTurn
        {
            get { return directYTurn; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    directYTurn = value;
                else
                {
                    directYTurn = 0;
                }
            }
        }

        protected HeroTank()
        {
            FieldSize = 450;
            CoordinateX = 240;
            CoordinateY = 480;
            DirectX = 0;
            DirectY = -1;
            DirectXTurn = DirectX;
            DirectYTurn = DirectY;

            ChooseImageDiraction();
        }

        public override void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                Img = heroTankImg.HeroTankImageRight;
            }

            if (DirectX == -1)
            {
                Img = heroTankImg.HeroTankImageLeft;
            }

            if (DirectY == 1)
            {
                Img = heroTankImg.HeroTankImageDown;
            }

            if (DirectY == -1)
            {
                Img = heroTankImg.HeroTankImageUp;
            }
        }

        public override void Turn()
        {
            DirectX = DirectXTurn;
            DirectY = DirectYTurn;

            ChooseImageDiraction();
        }

        public override void ReverseMove()
        {
            return;
        }
    }
}
