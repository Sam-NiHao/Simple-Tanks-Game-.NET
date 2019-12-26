using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

            Thread.Sleep(model.gameSpeed);
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
            e.Graphics.DrawImage(model.AwardImage.AwardImg, new Point(10, 520));
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
            for (int x = 40; x < 480; x += 80)
            {
                for (int y = 40; y < 480; y += 80)
                {
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
                }
            }

        }
    }
}
