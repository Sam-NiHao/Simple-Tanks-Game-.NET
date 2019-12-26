using System;
using System.Collections.Generic;
using System.Threading;
using Tanks.Addetion_classes;

namespace Tanks
{
    class Model
    {
        Random random;

        Missile missile;
        HeroTank heroTank;
        AwardImage awardImage;
        List<DestroyedTank> destroyedTanks;

        int fieldSize, tanksAmount, starsAmount, pickedUpStars;
        int gotStarPosition; 
        public int gameSpeed { get; set; }

        public GameStatus gameStatus;

        List<AbstractTank> enemyTanks;
        internal List<AbstractTank> EnemyTanks { get => enemyTanks; }

        List<Star> stars;
        internal List<Star> Stars { get => stars; }

        public Wall wall { get; set; }
        internal HeroTank HeroTank { get => heroTank; }
        internal AwardImage AwardImage { get => awardImage; }
        internal Missile Missile { get => missile; }
        internal List<DestroyedTank> DestroyedTanks { get => destroyedTanks; }

        public Model(int fieldSize, int tanksAmount, int starsAmount, int gameSpeed)
        {
            random = new Random();

            this.fieldSize = fieldSize;
            this.tanksAmount = tanksAmount;
            this.starsAmount = starsAmount;
            this.gameSpeed = gameSpeed;

            NewGame();
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
            while (EnemyTanks.Count < tanksAmount + 1)
                //while (EnemyTanks.Count == 0)
                {
                if (EnemyTanks.Count == 0)
                {
                    EnemyTanks.Add(new HunterTank(fieldSize, random.Next(6) * 80, random.Next(6) * 80));
                }

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

                Missile.Move();

                HeroTank.Move();
                ((HunterTank)EnemyTanks[0]).Move(HeroTank.CoordinateX, HeroTank.CoordinateY);

                for (int i = 1; i < EnemyTanks.Count; i++)
                {
                    EnemyTanks[i].Move();
                }

                foreach (var destroyTank in DestroyedTanks)
                {
                    destroyTank.Fire();
                }

                for (int i = 1; i < EnemyTanks.Count; i++)
                {
                    //if ((Missile.CoordinateX - EnemyTanks[i].CoordinateX) < 39 && (Missile.CoordinateY - EnemyTanks[i].CoordinateY) < 39
                    //    &&
                    //    (Missile.CoordinateX - EnemyTanks[i].CoordinateX) > 14 && (Missile.CoordinateY - EnemyTanks[i].CoordinateY) > 14)
                    if(Math.Abs(EnemyTanks[i].CoordinateX - Missile.CoordinateX) < 25 && Math.Abs(EnemyTanks[i].CoordinateY - Missile.CoordinateY) < 25)
                    {
                        DestroyedTanks.Add(new DestroyedTank(EnemyTanks[i].CoordinateX, EnemyTanks[i].CoordinateY));
                        EnemyTanks.RemoveAt(i);
                        missile.DefaultSettings();
                    }
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

        internal void NewGame()
        {
            pickedUpStars = 0;
            gotStarPosition = 500;

            missile = new Missile();
            heroTank = new HeroTank(fieldSize);
            enemyTanks = new List<AbstractTank>();
            stars = new List<Star>();
            awardImage = new AwardImage();
            destroyedTanks = new List<DestroyedTank>();

            CreateEnemyTanks();
            CreateStars();

            wall = new Wall();

            gameStatus = GameStatus.stopping;
        }
    }
}