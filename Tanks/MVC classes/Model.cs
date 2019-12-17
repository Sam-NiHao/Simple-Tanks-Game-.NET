using System;
using System.Collections.Generic;
using System.Threading;
using Tanks.Addetion_classes;

namespace Tanks
{
    class Model
    {
        Random random;

        int fieldSize, tanksAmount, applesAmount;
        public int gameSpeed { get; set; }

        public GameStatus gameStatus;

        //public EnemyTank tank { get; set; }

        List<EnemyTank> enemyTanks;
        internal List<EnemyTank> EnemyTanks { get => enemyTanks; }

        public Wall wall { get; set; }

        public Model(int fieldSize, int tanksAmount, int applesAmount, int gameSpeed)
        {
            random = new Random();

            enemyTanks = new List<EnemyTank>();

            this.fieldSize = fieldSize;
            this.tanksAmount = tanksAmount;
            this.applesAmount = applesAmount;
            this.gameSpeed = gameSpeed;

            //tank = new EnemyTank(fieldSize);
            CreateAllEnemyTanks();

            wall = new Wall();

            gameStatus = GameStatus.stopping;
        }

        private void CreateAllEnemyTanks()
        {
            int x, y;
            while(EnemyTanks.Count < tanksAmount)
            {
                x = random.Next(6) * 80;
                y = random.Next(6) * 80;

                bool flag = true;

                foreach (var tank in EnemyTanks)
                {
                    if(tank.CoordinateX == x && tank.CoordinateY == y)
                    {
                        flag = false;
                        break;
                    }
                }

                if(flag)
                {
                    EnemyTanks.Add(new EnemyTank(fieldSize, x, y));
                }
            }
        }

        public void StartGame()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(gameSpeed);

                foreach (var tank in EnemyTanks)
                {
                    tank.Move();
                }

                //tank.Move();
            }
        }
    }
}  