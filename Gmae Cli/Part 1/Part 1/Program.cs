using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Threading;

namespace Part_1
{
    class Program
    {
        public static List<Ghost> ghosts = new List<Ghost>();

        static void Main(string[] args)
        {
            int ascii5 = 1;
            int ascii1 = 219;
            int ascii2 = 900;
            char defender3 = Convert.ToChar(ascii1);
            char defender4 = Convert.ToChar(ascii2);
            char baller = Convert.ToChar(ascii5);
            GameGrid grid = new GameGrid("mazes.txt", 36 , 114);
            GameCell start = new GameCell(6, 14 , grid);
            GameCell start1 = new GameCell(13, 20, grid);
            GameCell start2 = new GameCell(10, 50, grid);
            GameCell start3 = new GameCell(19, 25, grid);
            PacmanPlayer pacman = new PacmanPlayer(baller, start);
           Ghost ghost = new Horizontal_Ghost(defender4 , start1);
            Ghost ghost1 = new VerticalGhost(defender3, start2);
            Ghost ghost3 = new RandomGhost('G', start3);
            ghosts.Add(ghost);
            ghosts.Add(ghost1);
            ghosts.Add(ghost3);
            printMaze(grid);
            printGameObject(pacman);
            printGhost(ghost);
            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman, GameDirection.Up);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, GameDirection.Down);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.Right);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.Left);
                }
               moveGhost();
            }
        }
        public static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.CurrentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.Y, gameCell.X);
            Console.Write(newGameObject.DisplayCharacter);

        }
        public static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.currentCell.Y, gameObject.currentCell.X);
            Console.Write(gameObject.DisplayCharacter);

        }
        public static void printGhost(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.currentCell.Y, gameObject.currentCell.X);
            Console.Write(gameObject.DisplayCharacter);
        }
        public static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.currentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = gameObject.currentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.currentCell = nextCell;
                printGameObject(gameObject);
            }
        }
        public static void moveGhost()
        {
            foreach (Ghost g in ghosts)
            {
                GameCell currentCell = g.currentCell;
                GameCell nextCell = g.Move(currentCell);
                if (nextCell != null)
                {
                    GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                    clearGameCellContent(currentCell, newGO);
                    g.currentCell = nextCell;
                    printGhost(g);
                }

            }

        }
        public static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.rows; x++)
            {
                for (int y = 0; y < grid.columns; y++)
                {
                    GameCell cell = grid.GetCell(x, y);
                    printCell(cell);
                }

            }
        } 
        public static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

    }
}

