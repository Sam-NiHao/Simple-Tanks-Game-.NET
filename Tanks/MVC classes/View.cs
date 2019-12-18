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
            DrawStar(e);
            DrawEnemyTank(e);

            if (model.gameStatus != GameStatus.playing)
                return;

            Thread.Sleep(model.gameSpeed);
            Invalidate();
        }

        private void DrawStar(PaintEventArgs e)
        {
            foreach (var star in model.Stars)
            {
                e.Graphics.DrawImage(star.Img, new Point(star.CoordinateX, star.CoordinateY));
            }
        }

        public void DrawEnemyTank(PaintEventArgs e)
        {
            foreach (var tank in model.EnemyTanks)
            {
                e.Graphics.DrawImage(tank.Img, new Point(tank.CoordinateX, tank.CoordinateY));
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
