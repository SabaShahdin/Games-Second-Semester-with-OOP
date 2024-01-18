using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
namespace game
{
    public partial class QatarFifa : Form
    {
        GamePlayer pacman;
        public static int Score = 0;
        public static int Health = 100;
        public static int Bonus = 0;
        public static int Energy = 0;
        public static int Lives = 3;
        HorizontalDefender horizontal;
        VerticalDefender goalkeeper;
        GameGrid grid;
        public static List<Defender> ghost = new List<Defender>();
        public static List<Bullet> Bullets = new List<Bullet>();
        public static List<BulletEnemy> enemybullets = new List<BulletEnemy>();
        public QatarFifa()
        {
            InitializeComponent();
        }

        private void QatarFifa_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("mazes.txt", 32, 53);
            Image pacManImage = Game.getGameObjectImage('P');
            Image bulletImage = Game.getGameObjectImage('-');
            Image HorizontalGhost = Game.getGameObjectImage('H');
            Image VerticalGhost = Game.getGameObjectImage('V');
            Image GoalKeeperGhost = Game.getGameObjectImage('v');
            Image randomGhost = Game.getGameObjectImage('R');
            GameCell startCell = grid.getCell(7, 10);
            GameCell startGhost = grid.getCell(19, 11);
            GameCell Defender = grid.getCell(5, 31);
            GameCell GoalKeeper = grid.getCell(3, 41);
            GameCell startRandom = grid.getCell(29, 15);
            GameLoop.Start();
            bulletTimer.Start();
            pacman = new GamePlayer(pacManImage, startCell);
            horizontal = new HorizontalDefender(HorizontalGhost, startGhost);
            Defender vertical = new RandomDefender(VerticalGhost, Defender);
            Defender random = new RandomDefender(randomGhost, startRandom);
            goalkeeper = new VerticalDefender(GoalKeeperGhost, GoalKeeper);
            printMaze(grid);
            ghost.Add(horizontal);
            ghost.Add(vertical);
            ghost.Add(random);
            ghost.Add(goalkeeper);
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }

        public static void moveGhost()
        {
            foreach (Defender g in ghost)
            {
                g.Move();
            }
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pacman.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pacman.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pacman.move(GameDirection.Down);
            }
            generateEnemyBullet(horizontal, GameDirection.Up);
            generateEnemyBullet(horizontal, GameDirection.Down);
            generateEnemyBullet(goalkeeper, GameDirection.Left);
            generateEnemyBullet(goalkeeper, GameDirection.Right);
            MoveEnemyBullets();
            moveGhost();
            txtScore.Text = Score.ToString();
            txtBonus.Text = Bonus.ToString();
            txtEnergy.Text = Energy.ToString();
            txtLivess.Text = Lives.ToString();
            healthBar.Value = Health;

        }

        private void bulletTimer_Tick_1(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyPressed(Key.A))
            {
                generateBullet(pacman, GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                generateBullet(pacman, GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.S))
            {
                generateBullet(pacman, GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.D))
            {
                generateBullet(pacman, GameDirection.Down);
            }
            MoveBullets();
        }
        public static void generateBullet(GamePlayer pacman, GameDirection direction)
        {

            GameCell startCell = pacman.CurrentCell.nextBulletCell(direction);
            if (startCell != null)
            {
                if (direction == GameDirection.Up || direction == GameDirection.Down)
                {
                    Image bulletImage = Game.getGameObjectImage('-');
                    Bullet bullet = new Bullet(startCell, direction, bulletImage);
                    Bullets.Add(bullet);
                    startCell.setGameObject(bullet);
                    bullet.IsActive = true;
                }
                if (direction == GameDirection.Left || direction == GameDirection.Right)
                {
                    Image bulletImage = Game.getGameObjectImage('&');
                    Bullet bullet = new Bullet(startCell, direction, bulletImage);
                    Bullets.Add(bullet);
                    startCell.setGameObject(bullet);
                    bullet.IsActive = true;
                }

            }
        }


        public void MoveBullets()
        {
            List<Bullet> bulletsToRemove = new List<Bullet>();
            foreach (Bullet bullet in Bullets)
            {
                GameCell currentCell = bullet.CurrentCell;
                GameCell nextCell = currentCell.nextBulletCell(bullet.Direction);

                if (nextCell != currentCell)
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE || nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                    {
                        currentCell.setGameObject(Game.getBlankGameObject());
                        bullet.CurrentCell = nextCell;
                        nextCell.setGameObject(bullet);
                        bullet.IsActive = true;
                    }
                    else
                    {
                        bullet.IsActive = false;
                    }
                }
                else
                {
                    bullet.IsActive = false;
                }

                if (!bullet.IsActive)
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            foreach (Bullet bullet in bulletsToRemove)
            {
                bullet.CurrentCell.setGameObject(Game.getBlankGameObject());
                Bullets.Remove(bullet);
            }
        }

        public static void DecreaseHealth()
        {
            Health = Health - 5;
            if (Health == 0)
            {
                Lives = Lives - 1;
                Health = 100;
            }
        }
        public static void DecreaseLives()
        {
            if (Lives == 0)
            {
                Form form = new Lose();
                form.Show();
            }

        }
        public static void Scoring()
        {
            Score = Score + 1;
        }
        public static void bonus()
        {
            Bonus = Bonus + 5;
        }
        public static void energize()
        {
            Energy = Energy + 1;
        }
        public void generateEnemyBullet(Defender defender, GameDirection direction)
        {
            GameCell startCell = defender.CurrentCell.nextCell(direction);
            if (startCell != null)
            {
                if (direction == GameDirection.Up || direction == GameDirection.Down)
                {
                    Image bulletImage = Game.getGameObjectImage('B');
                    BulletEnemy enemyBullet = new BulletEnemy(startCell, direction, bulletImage);
                    enemybullets.Add(enemyBullet);
                    startCell.setGameObject(enemyBullet);
                    enemyBullet.IsActive = true;
                }
                if (direction == GameDirection.Left || direction == GameDirection.Right)
                {
                    Image bulletImage = Game.getGameObjectImage('A');
                    BulletEnemy enemyBullet = new BulletEnemy(startCell, direction, bulletImage);
                    enemybullets.Add(enemyBullet);
                    startCell.setGameObject(enemyBullet);
                    enemyBullet.IsActive = true;
                }
            }


        }
        public void MoveEnemyBullets()
        {
            List<BulletEnemy> bulletsToRemove = new List<BulletEnemy>();
            foreach (BulletEnemy bullet in enemybullets)
            {
                GameCell currentCell = bullet.CurrentCell;
                GameCell nextCell = currentCell.nextCell(bullet.Direction);

                if (nextCell != currentCell)
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE) 
                    {
                        currentCell.setGameObject(Game.getBlankGameObject());
                        bullet.CurrentCell = nextCell;
                        nextCell.setGameObject(bullet);
                        bullet.IsActive = true;
                    }
                    else
                    {
                        bullet.IsActive = false;
                    }
                }
                else
                {
                    bullet.IsActive = false;
                }

                if (!bullet.IsActive)
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            foreach (BulletEnemy bullet in bulletsToRemove)
            {
                bullet.CurrentCell.setGameObject(Game.getBlankGameObject());
                enemybullets.Remove(bullet);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new Main();
            form.Show();
            this.Hide();
        }
    }
}
