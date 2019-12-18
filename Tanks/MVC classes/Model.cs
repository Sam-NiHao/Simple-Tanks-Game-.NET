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

                for (int i = 0; i < EnemyTanks.Count - 1; i++)
                {
                    for (int j = i + 1; j < EnemyTanks.Count; j++)
                    {
                        if (
                            (Math.Abs(enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX) <= 40 && (enemyTanks[i].CoordinateY == enemyTanks[j].CoordinateY)) //горизонтальная проверка
                            ||
                            (Math.Abs(enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY) <= 40 && (enemyTanks[i].CoordinateX == enemyTanks[j].CoordinateX)) // вертикальная проверка
                            ||
                            (Math.Abs(enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX) <= 40 && Math.Abs(enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY) <= 40) // угловая проверка
                          )
                        //if (
                        //    (Math.Abs(enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX) <= 40 && (enemyTanks[i].CoordinateY == enemyTanks[j].CoordinateY))
                        //    ||
                        //    (Math.Abs(enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY) <= 40 && (enemyTanks[i].CoordinateX == enemyTanks[j].CoordinateX))
                        //    ||
                        //    (enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX == 40 && enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY == 40) && (enemyTanks[i].DirectY == -1 || enemyTanks[i].DirectX == -1)
                        //    ||
                        //    (enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX == -40 && enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY == -40) && (enemyTanks[j].DirectY == -1 || enemyTanks[j].DirectX == -1)
                        //    ||
                        //    (enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX == 40 && enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY == 40) && (enemyTanks[i].DirectY == -1 || enemyTanks[i].DirectX == -1)
                        //    ||
                        //    (enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX == 40 && enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY == -40) && (enemyTanks[j].DirectY == -1 || enemyTanks[j].DirectX == 1)
                        //    ||
                        //    (enemyTanks[i].CoordinateX - enemyTanks[j].CoordinateX == -40 && enemyTanks[i].CoordinateY - enemyTanks[j].CoordinateY == 40) && (enemyTanks[i].DirectY == -1 || enemyTanks[i].DirectX == 1)
                        //  )
                        {
                            enemyTanks[i].ReverseMove();
                            enemyTanks[j].ReverseMove();
                        }
                    }
                }
            }
        }
    }
}  