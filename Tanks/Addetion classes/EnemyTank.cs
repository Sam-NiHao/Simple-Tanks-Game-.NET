namespace Tanks
{
    class EnemyTank : AbstractTank
    {
        EnemyTankImage enemyTankImg = new EnemyTankImage();

        public EnemyTank(int fieldSize, int enemyTankCoordinateX, int enemyTankCoordinateY)
        {
            FieldSize = fieldSize;

            ChooseDiractionForTanks();

            ChooseImageDiraction();

            CoordinateX = enemyTankCoordinateX;
            CoordinateY = enemyTankCoordinateY;
        }

        public override void ChooseImageDiraction()
        {
            if (DirectX == 1)
            {
                Img = enemyTankImg.TankImageRight;
            }

            if (DirectX == -1)
            {
                Img = enemyTankImg.TankImageLeft;
            }

            if (DirectY == 1)
            {
                Img = enemyTankImg.TankImageDown;
            }

            if (DirectY == -1)
            {
                Img = enemyTankImg.TankImageUp;
            }
        }
    }
}
