using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Tanks
{
    partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawWalls(e);
            DrawDestroyedTank(e);
            DrawStar(e);
            DrawEnemyTank(e);
            DrawHeroTank(e);
            DrawAward(e);
            DrawMissile(e);
            
            if (model.gameStatus != GameStatus.playing)
                return;

            Thread.Sleep(model.GameSpeed);

            Invalidate();
        }

        private void DrawDestroyedTank(PaintEventArgs e)
        {
            foreach (var destroyTank in model.DestroyedTanks)
            {
                e.Graphics.DrawImage(destroyTank.Img, new Point(destroyTank.CoordinateX, destroyTank.CoordinateY));
            } 
        }

        private void DrawMissile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Missile.Img, new Point(model.Missile.CoordinateX, model.Missile.CoordinateY));
        }

        private void DrawAward(PaintEventArgs e)
        {
            int awardPositionCoordinateX = 10;
            int awardPositionCoordinateY = 520;

            e.Graphics.DrawImage(model.AwardImage.AwardImg, new Point(awardPositionCoordinateX, awardPositionCoordinateY));
        }

        private void DrawHeroTank(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.HeroTank.Img, new Point(model.HeroTank.CoordinateX, model.HeroTank.CoordinateY));
        }

        private void DrawStar(PaintEventArgs e)
        {
            for (int i = 0; i < model.Stars.Count; i++)
            {
                e.Graphics.DrawImage(model.Stars[i].Img, new Point(model.Stars[i].CoordinateX, model.Stars[i].CoordinateY));
            }
        }

        public void DrawEnemyTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.EnemyTanks.Count; i++)
            {
                e.Graphics.DrawImage(model.EnemyTanks[i].Img, new Point(model.EnemyTanks[i].CoordinateX, model.EnemyTanks[i].CoordinateY));
            }
        }

        public void DrawWalls(PaintEventArgs e)
        {
            int wallSizeX, wallSizeY;
            int gameFieldSize = 480;
            int distanceBetweenWalls = 80;

            for (wallSizeX = 40; wallSizeX < gameFieldSize; wallSizeX += distanceBetweenWalls)
            {
                for (wallSizeY = 40; wallSizeY < gameFieldSize; wallSizeY += distanceBetweenWalls)
                {
                    e.Graphics.DrawImage(model.Wall.Img, new Point(wallSizeX,wallSizeY));
                }
            }

        }
    }
}
