using System;
using System.Collections.Generic;
using System.Threading;
using Tanks.Addetion_classes;//11111111111111111111111111111111111111

namespace Tanks
{
    public delegate void Streep();// name!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    class Model
    {
        public event Streep changeStatusStreep;
        public GameStatus gameStatus;

        Random random;

        AwardImage awardImage;
        internal AwardImage AwardImage { get => awardImage; }

        Missile missile;
        internal Missile Missile { get => missile; }

        HeroTank heroTank;
        internal HeroTank HeroTank { get => heroTank; }
        
        List<DestroyedTank> destroyedTanks;
        internal List<DestroyedTank> DestroyedTanks { get => destroyedTanks; }

        List<Star> stars;
        internal List<Star> Stars { get => stars; }

        List<AbstractTank> enemyTanks;
        internal List<AbstractTank> EnemyTanks { get => enemyTanks; }


        int fieldSize, tanksAmount, starsAmount, pickedUpStars, gotStarPosition;

        public int gameSpeed { get; } // field?? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public Wall wall { get; set; }// свойство??   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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
            int starCoordinateX, starCoordinateY;

            while (Stars.Count < starsAmount + pickedUpStars)
            {
                starCoordinateX = random.Next(6) * 80;//переименовать 6 и 80
                starCoordinateY = random.Next(6) * 80;//переименовать 6 и 80

                bool flag = true;

                foreach (var star in Stars)
                {
                    if (star.CoordinateX == starCoordinateX && star.CoordinateY == starCoordinateY)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Stars.Add(new Star(starCoordinateX, starCoordinateY));
                }
            }
        }

        private void CreateEnemyTanks()
        {
            int enemyTankCoordinateX, enemyTankCoordinateY;

            while (EnemyTanks.Count < tanksAmount + 1)
            {
                if (EnemyTanks.Count == 0)
                {
                    EnemyTanks.Add(new HunterTank(fieldSize, random.Next(6) * 80, random.Next(6) * 80)); //переименовать 6 и 80
                }

                enemyTankCoordinateX = random.Next(6) * 80; //переименовать 6 и 80
                enemyTankCoordinateY = random.Next(6) * 80; //переименовать 6 и 80

                bool flag = true;

                foreach (var tank in EnemyTanks)
                {
                    if (tank.CoordinateX == enemyTankCoordinateX && tank.CoordinateY == enemyTankCoordinateY)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    EnemyTanks.Add(new EnemyTank(fieldSize, enemyTankCoordinateX, enemyTankCoordinateY));
                }
            }
        }

        public void StartGame()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(gameSpeed);

                MoveAllObjectsOnField();

                foreach (var destroyTank in DestroyedTanks)
                {
                    destroyTank.Fire();
                }

                TryDestroyEnemyTank();

                MakeTanksReverse();

                CheckImpactEnemyTankWithHeroTank();

                PickUpStars();
            }
        }

        private void MoveAllObjectsOnField()
        {
            Missile.Move();

            HeroTank.Move();
            ((HunterTank)EnemyTanks[0]).Move(HeroTank.CoordinateX, HeroTank.CoordinateY);

            for (int i = 1; i < EnemyTanks.Count; i++)
            {
                EnemyTanks[i].Move();
            }
        }

        private void PickUpStars()
        {
            for (int i = 0; i < Stars.Count; i++)
            {
                if (HeroTank.CoordinateX == Stars[i].CoordinateX && HeroTank.CoordinateY == Stars[i].CoordinateY)
                {
                    Stars[i] = new Star(gotStarPosition -= 45, 530); //переименовать 45, 530
                    CreateStars(++pickedUpStars);
                }

                if (pickedUpStars > 5) //переименовать 5
                {
                    gameStatus = GameStatus.winner;

                    changeStatusStreep?.Invoke();
                }
            }
        }

        private void CheckImpactEnemyTankWithHeroTank()
        {
            for (int i = 0; i < EnemyTanks.Count; i++)
            {
                if (
                        (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= 39 && (EnemyTanks[i].CoordinateY == HeroTank.CoordinateY)) //переименовать 39
                        ||
                        (Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= 39 && (EnemyTanks[i].CoordinateX == HeroTank.CoordinateX)) //переименовать 39
                        ||
                        (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= 39 && Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= 39) //переименовать 39
                    )
                {
                    gameStatus = GameStatus.loser;

                    changeStatusStreep?.Invoke();
                }
            }
        }

        private void MakeTanksReverse()
        {
            for (int i = 0; i < EnemyTanks.Count - 1; i++)
            {
                for (int j = i + 1; j < EnemyTanks.Count; j++)
                {
                    if (
                        (Math.Abs(EnemyTanks[i].CoordinateX - EnemyTanks[j].CoordinateX) <= 40 && (EnemyTanks[i].CoordinateY == EnemyTanks[j].CoordinateY)) //горизонтальная проверка //переименовать 40
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
        }

        private void TryDestroyEnemyTank()
        {
            for (int i = 1; i < EnemyTanks.Count; i++)
            {
                //if ((Missile.CoordinateX - EnemyTanks[i].CoordinateX) < 39 && (Missile.CoordinateY - EnemyTanks[i].CoordinateY) < 39
                //    &&
                //    (Missile.CoordinateX - EnemyTanks[i].CoordinateX) > 14 && (Missile.CoordinateY - EnemyTanks[i].CoordinateY) > 14)
                if (Math.Abs(EnemyTanks[i].CoordinateX - Missile.CoordinateX) < 25 && Math.Abs(EnemyTanks[i].CoordinateY - Missile.CoordinateY) < 25) //переименовать 25
                {
                    DestroyedTanks.Add(new DestroyedTank(EnemyTanks[i].CoordinateX, EnemyTanks[i].CoordinateY));
                    EnemyTanks.RemoveAt(i);
                    missile.DefaultSettings();
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