using System;
using System.Collections.Generic;
using System.Threading;
using Tanks.Addetion_classes;

namespace Tanks
{
    class Model
    {
        Random random;

        HeroTank heroTank;
        AwardImage awardImage;

        int fieldSize, tanksAmount, starsAmount, pickedUpStars;
        int gotStarPosition = 500;
        public int gameSpeed { get; set; }

        public GameStatus gameStatus;

        List<EnemyTank> enemyTanks;
        internal List<EnemyTank> EnemyTanks { get => enemyTanks; }

        List<Star> stars;
        internal List<Star> Stars { get => stars; }

        public Wall wall { get; set; }
        internal HeroTank HeroTank { get => heroTank; set => heroTank = value; }
        internal AwardImage AwardImage { get => awardImage; }

        public Model(int fieldSize, int tanksAmount, int starsAmount, int gameSpeed)
        {
            random = new Random();

            HeroTank = new HeroTank(fieldSize);
            enemyTanks = new List<EnemyTank>();
            stars = new List<Star>();
            awardImage = new AwardImage();

            this.fieldSize = fieldSize;
            this.tanksAmount = tanksAmount;
            this.starsAmount = starsAmount;
            this.gameSpeed = gameSpeed;

            CreateEnemyTanks();
            CreateStars();

            wall = new Wall();

            gameStatus = GameStatus.stopping;
        }

        private void CreateStars()
        {
            CreateStars(0);
        }

        private void CreateStars(int pickedUpStars)
        {
            int x, y;
            while (Stars.Count < starsAmount + pickedUpStars)
            {
                x = random.Next(6) * 80;
                y = random.Next(6) * 80;

                bool flag = true;

                foreach (var star in Stars)
                {
                    if (star.CoordinateX == x && star.CoordinateY == y)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Stars.Add(new Star(x, y));
                }
            }
        }

        private void CreateEnemyTanks()
        {
            int x, y;
            while (EnemyTanks.Count < tanksAmount)
            {
                x = random.Next(6) * 80;
                y = random.Next(6) * 80;

                bool flag = true;

                foreach (var tank in EnemyTanks)
                {
                    if (tank.CoordinateX == x && tank.CoordinateY == y)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
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

                HeroTank.Move();

                foreach (var tank in EnemyTanks)
                {
                    tank.Move();
                }

                for (int i = 0; i < EnemyTanks.Count - 1; i++)
                {
                    for (int j = i + 1; j < EnemyTanks.Count; j++)
                    {
                        if (
                            (Math.Abs(EnemyTanks[i].CoordinateX - EnemyTanks[j].CoordinateX) <= 40 && (EnemyTanks[i].CoordinateY == EnemyTanks[j].CoordinateY)) //горизонтальная проверка
                            ||
                            (Math.Abs(EnemyTanks[i].CoordinateY - EnemyTanks[j].CoordinateY) <= 40 && (EnemyTanks[i].CoordinateX == EnemyTanks[j].CoordinateX)) // вертикальная проверка
                            ||
                            (Math.Abs(EnemyTanks[i].CoordinateX - EnemyTanks[j].CoordinateX) <= 40 && Math.Abs(EnemyTanks[i].CoordinateY - EnemyTanks[j].CoordinateY) <= 40) // угловая проверка
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
                            EnemyTanks[i].ReverseMove();
                            EnemyTanks[j].ReverseMove();
                        }
                    }
                }

                for (int i = 0; i < EnemyTanks.Count; i++)
                {
                    if (
                            (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= 39 && (EnemyTanks[i].CoordinateY == HeroTank.CoordinateY))
                            ||
                            (Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= 39 && (EnemyTanks[i].CoordinateX == HeroTank.CoordinateX))
                            ||
                            (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= 39 && Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= 39)
                        )
                        gameStatus = GameStatus.loser;
                }

                for (int i = 0; i < Stars.Count; i++)
                {
                    if (HeroTank.CoordinateX == Stars[i].CoordinateX && HeroTank.CoordinateY == Stars[i].CoordinateY)
                    {
                        Stars[i] = new Star(gotStarPosition -= 45, 530);
                        CreateStars(++pickedUpStars);
                    }

                    if (pickedUpStars > 2)
                    {
                        gameStatus = GameStatus.winner;
                    }
                }
            }
        }

    }
}