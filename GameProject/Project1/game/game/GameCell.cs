using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace game
{
    public class GameCell
    {
        int row;
        int col;
        GameObject currentGameObject;
        GameGrid grid;
        PictureBox pictureBox;
        int score = 0;
        const int width = 21;
        const int height = 21;

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
        public int Score { get => score; set => score = value; }

        public GameCell()
        {

        }
        public GameCell(int row, int col, GameGrid grid)
        {
            this.Row = row;
            this.Col = col;
            PictureBox = new PictureBox();
            PictureBox.Left = col * width;
            PictureBox.Top = row * height;
            PictureBox.Size = new Size(width, height);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.BackColor = Color.Transparent;
            this.Grid = grid;
        }
        public void setGameObject(GameObject gameObject)
        {
            CurrentGameObject = gameObject;
            PictureBox.Image = gameObject.Image;

        }
        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Left)
            {
                if (this.Col > 0)
                {
                    GameCell ncell = Grid.getCell(Row, Col - 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL && ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }
                   
                }
            }

            if (direction == GameDirection.Right)
            {
                if (this.Col < Grid.Cols - 1)
                {
                    GameCell ncell = Grid.getCell(this.Row, this.Col + 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL && ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY )
                    {
                        return ncell;
                    }
                 
                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.Row > 0)
                {
                    GameCell ncell = Grid.getCell(this.Row - 1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL && ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }
                  
                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.Row < Grid.Rows - 1)
                {
                    GameCell ncell = Grid.getCell(this.Row + 1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL && ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY )
                    {
                        return ncell;
                    }
                  
                }
            }
            return this; 
        }
        public GameCell nextBulletCell(GameDirection direction)
        {
            if (direction == GameDirection.Left)
            {
                if (this.Col > 0)
                {
                    GameCell ncell = Grid.getCell(Row, Col - 1);
                    if ( ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }

                }
            }

            if (direction == GameDirection.Right)
            {
                if (this.Col < Grid.Cols - 1)
                {
                    GameCell ncell = Grid.getCell(this.Row, this.Col + 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }

                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.Row > 0)
                {
                    GameCell ncell = Grid.getCell(this.Row - 1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }

                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.Row < Grid.Rows - 1)
                {
                    GameCell ncell = Grid.getCell(this.Row + 1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
                    {
                        return ncell;
                    }

                }
            }
            return this;
        }
      

    }
}
