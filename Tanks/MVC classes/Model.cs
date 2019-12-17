using System.Threading;
using Tanks.Addetion_classes;

namespace Tanks
{
    class Model
    {
        int fieldSize, tanksAmount, applesAmount;
        public int gameSpeed { get; set; }

        public GameStatus gameStatus;

        public EnemyTank tank { get; set; }

        public Wall wall { get; set; }

        public Model(int fieldSize, int tanksAmount, int applesAmount, int gameSpeed)
        {
            this.fieldSize = fieldSize;
            this.tanksAmount = tanksAmount;
            this.applesAmount = applesAmount;
            this.gameSpeed = gameSpeed;

            tank = new EnemyTank(fieldSize);
            wall = new Wall();

            gameStatus = GameStatus.stopping;
        }

        public void StartGame()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(gameSpeed);
                tank.Move();
            }
        }
    }
}  