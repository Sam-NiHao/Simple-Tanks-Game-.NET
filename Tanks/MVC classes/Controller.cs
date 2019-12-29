using System;
using System.Threading;
using System.Windows.Forms;

namespace Tanks
{
    public partial class ControllerMainForm : Form
    {
        View view;

        Model model;

        Thread modelPlay;

        public ControllerMainForm() : this(450) { }
        public ControllerMainForm(int fieldSize) : this(fieldSize, 5) { }
        public ControllerMainForm(int fieldSize, int tanksAmount) : this(fieldSize, tanksAmount, 5) { }
        public ControllerMainForm(int fieldSize, int tanksAmount, int starsAmount) : this(fieldSize, tanksAmount, starsAmount, 30) { }
        public ControllerMainForm(int fieldSize, int tanksAmount, int starsAmount, int gameSpeed)
        {
            InitializeComponent();

            model = new Model(fieldSize, tanksAmount, starsAmount, gameSpeed);
            model.changeStatusStreep += new Streep(ShowGameStatusInStatusStrip);

            view = new View(model);
            this.Controls.Add(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        void ShowGameStatusInStatusStrip()
        {
            GameStatusStrip.Text = model.gameStatus.ToString();
        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stopping;
                ShowGameStatusInStatusStrip();
            }
            else
            {
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.StartGame);
                modelPlay.Start();
                ShowGameStatusInStatusStrip();
                view.Invalidate();
            }
        }

        private void ControllerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(modelPlay != null)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stopping;
            }
        }

        private void HeroTankHandling(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                case 'A':
                    model.HeroTank.DirectXTurn = -1;
                    model.HeroTank.DirectYTurn = 0;
                    break;
                case 'd':
                case 'D':
                    model.HeroTank.DirectXTurn = 1;
                    model.HeroTank.DirectYTurn = 0;
                    break;
                case 'w':
                case 'W':
                    model.HeroTank.DirectXTurn = 0;
                    model.HeroTank.DirectYTurn = -1;
                    break;
                case 's':
                case 'S':
                    model.HeroTank.DirectXTurn = 0;
                    model.HeroTank.DirectYTurn = 1;
                    break;
                default:
                    {
                        SetMissileDirection();
                        SetMissileCoordinates();
                    }
                    break;
            }
        }

        private void SetMissileDirection()
        {
            model.Missile.DirectX = model.HeroTank.DirectX;
            model.Missile.DirectY = model.HeroTank.DirectY;
        }

        private void SetMissileCoordinates()
        {
            if (model.HeroTank.DirectY == -1)
            {
                model.Missile.CoordinateX = model.HeroTank.CoordinateX;
                model.Missile.CoordinateY = model.HeroTank.CoordinateY - 35;
            }

            if (model.HeroTank.DirectY == 1)
            {
                model.Missile.CoordinateX = model.HeroTank.CoordinateX;
                model.Missile.CoordinateY = model.HeroTank.CoordinateY + 35; //переименовать 35
            }

            if (model.HeroTank.DirectX == -1)
            {
                model.Missile.CoordinateX = model.HeroTank.CoordinateX - 35;
                model.Missile.CoordinateY = model.HeroTank.CoordinateY;
            }

            if (model.HeroTank.DirectX == 1)
            {
                model.Missile.CoordinateX = model.HeroTank.CoordinateX + 35;
                model.Missile.CoordinateY = model.HeroTank.CoordinateY;
            }
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            model.NewGame();
            view.Refresh();
        }
    }
}
