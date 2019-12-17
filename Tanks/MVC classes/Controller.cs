﻿using System;
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
        public ControllerMainForm(int fieldSize, int tanksAmount, int applesAmount) : this(fieldSize, tanksAmount, applesAmount, 30) { }
        public ControllerMainForm(int fieldSize, int tanksAmount, int applesAmount, int gameSpeed)
        {
            InitializeComponent();

            model = new Model(fieldSize, tanksAmount, applesAmount, gameSpeed);

            view = new View(model);
            this.Controls.Add(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stopping;
            }
            else
            {
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.StartGame);
                modelPlay.Start();

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
    }
}