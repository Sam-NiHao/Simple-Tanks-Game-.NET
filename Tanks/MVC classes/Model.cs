using System;
using System.Collections.Generic;
using System.Threading;

namespace Tanks
{
    public delegate void Strip();
    class Model
    {
        public event Strip changeStatusStreep;
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

        public int GameSpeed { get; }

        Wall wall;
        internal Wall Wall { get => wall; }

        public Model(int fieldSize, int tanksAmount, int starsAmount, int gameSpeed)
        {
            random = new Random();

            this.fieldSize = fieldSize;
            this.tanksAmount = tanksAmount;
            this.starsAmount = starsAmount;
            this.GameSpeed = gameSpeed;

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
                starCoordinateX = GetRandomCoordinate();
                starCoordinateY = GetRandomCoordinate();

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

        private int GetRandomCoordinate()
        {
            int amountWallRows = 6;
            int distanceBetweenWallCoordinates = 80;

            return random.Next(amountWallRows) * distanceBetweenWallCoordinates;
        }

        private void CreateEnemyTanks()
        {
            int enemyTankCoordinateX, enemyTankCoordinateY;

            while (EnemyTanks.Count < tanksAmount + 1)
            {
                if (EnemyTanks.Count == 0)
                {
                    EnemyTanks.Add(new HunterTank(fieldSize, GetRandomCoordinate(), GetRandomCoordinate()));
                }

                enemyTankCoordinateX = GetRandomCoordinate();
                enemyTankCoordinateY = GetRandomCoordinate();

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
                Thread.Sleep(GameSpeed);

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
            int trophyStarCoordinateX = 48;
            int trophyStarCoordinateY = 530;
            int amountStarsNeedToWin = 8;

            for (int i = 0; i < Stars.Count; i++)
            {
                if (HeroTank.CoordinateX == Stars[i].CoordinateX && HeroTank.CoordinateY == Stars[i].CoordinateY)
                {
                    Stars[i] = new Star(gotStarPosition -= trophyStarCoordinateX, trophyStarCoordinateY);
                    CreateStars(++pickedUpStars);
                }

                CheckAmountStars(amountStarsNeedToWin);
            }
        }

        private void CheckAmountStars(int amountStarsNeedToWin)
        {
            if (pickedUpStars > amountStarsNeedToWin)
            {
                gameStatus = GameStatus.winner;

                changeStatusStreep?.Invoke();
            }
        }

        private void CheckImpactEnemyTankWithHeroTank()
        {
            for (int i = 0; i < EnemyTanks.Count; i++)
            {
                CheckEnemyAndHeroTanksCoordinates(i);
            }
        }

        private void CheckEnemyAndHeroTanksCoordinates(int i)
        {
            int tnakSize = 39;

            if (
                 (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= tnakSize && (EnemyTanks[i].CoordinateY == HeroTank.CoordinateY))
                 ||
                 (Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= tnakSize && (EnemyTanks[i].CoordinateX == HeroTank.CoordinateX))
                 ||
                 (Math.Abs(EnemyTanks[i].CoordinateX - HeroTank.CoordinateX) <= tnakSize && Math.Abs(EnemyTanks[i].CoordinateY - HeroTank.CoordinateY) <= tnakSize)
               )
            {
                gameStatus = GameStatus.loser;

                changeStatusStreep?.Invoke();
            }
        }

        private void MakeTanksReverse()
        {
            for (int i = 0; i < EnemyTanks.Count - 1; i++)
            {
                for (int j = i + 1; j < EnemyTanks.Count; j++)
                {
                    CheckEnemyTanksCoordinates(i, j);
                }
            }
        }

        private void CheckEnemyTanksCoordinates(int i, int j)
        {
            int tnakSize = 40;

            if (
                  (Math.Abs(EnemyTanks[i].CoordinateX - EnemyTanks[j].CoordinateX) <= tnakSize && (EnemyTanks[i].CoordinateY == EnemyTanks[j].CoordinateY)) //горизонтальная проверка
                  ||
                  (Math.Abs(EnemyTanks[i].CoordinateY - EnemyTanks[j].CoordinateY) <= tnakSize && (EnemyTanks[i].CoordinateX == EnemyTanks[j].CoordinateX)) // вертикальная проверка
                  ||
                  (Math.Abs(EnemyTanks[i].CoordinateX - EnemyTanks[j].CoordinateX) <= tnakSize && Math.Abs(EnemyTanks[i].CoordinateY - EnemyTanks[j].CoordinateY) <= tnakSize) // угловая проверка
               )
            {
                ReverseMoveForEnemyTanks(i, j);
            }
        }

        private void ReverseMoveForEnemyTanks(int i, int j)
        {
            EnemyTanks[i].ReverseMove();
            EnemyTanks[j].ReverseMove();
        }

        private void TryDestroyEnemyTank()
        {
            for (int i = 1; i < EnemyTanks.Count; i++)
            {
                CheckEnemyTanksAndMissileCoordinates(i);
            }
        }

        private void CheckEnemyTanksAndMissileCoordinates(int i)
        {
            int enoughDistanceToKillTank = 25;

            if (Math.Abs(EnemyTanks[i].CoordinateX - Missile.CoordinateX) < enoughDistanceToKillTank && Math.Abs(EnemyTanks[i].CoordinateY - Missile.CoordinateY) < enoughDistanceToKillTank)
            {
                DestroyedTanks.Add(new DestroyedTank(EnemyTanks[i].CoordinateX, EnemyTanks[i].CoordinateY));
                EnemyTanks.RemoveAt(i);
                missile.DefaultSettings();
            }
        }

        internal void NewGame()
        {
            pickedUpStars = 0;
            gotStarPosition = 500;

            missile = new Missile();
            heroTank = HeroTank.SingeltonMethod();
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