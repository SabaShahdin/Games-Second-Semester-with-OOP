﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Games.GameGL
{
    public class GameCell
    {
        int row;
        int col;
        GameObject currentGameObject;
        GameGrid grid;
        PictureBox pictureBox;
        const int width = 20;
        const int height = 20;
         static int score = 0 ;
        public Bullet CurrentBullet { get; set; }
        public GameCell()
        {

        }
        public GameCell(int row, int col, GameGrid grid)
        {
            this.row = row;
            this.col = col;
            pictureBox = new PictureBox();
            pictureBox.Left = col * width;
            pictureBox.Top = row * height;
            pictureBox.Size = new Size(width, height);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;
            this.grid = grid;
        }
       /* public void setGameObject(GameObject gameObject)
        {
            currentGameObject = gameObject;
            pictureBox.Image = gameObject.Image;

        }*/
        public void setGameObject(GameObject gameObject)
        {
            if (gameObject is Bullet)
            {
                this.CurrentBullet = (Bullet)gameObject;
            }
            else
            {
                this.currentGameObject = gameObject;
            }

            pictureBox.Image = gameObject.Image;
        }
        public GameCell nextCell(GameDirection direction)
        {
           // int score = 0;
            if (direction == GameDirection.Left)
            {
                if (this.col > 0)
                {
                    GameCell ncell = grid.getCell(row, col - 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Right)
            {
                if (this.col < grid.Cols - 1)
                {
                    GameCell ncell = grid.getCell(this.row, this.col + 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
                    {
                        return ncell;
                    }
                   
                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.row > 0)
                {
                    GameCell ncell = grid.getCell(this.row - 1, this.col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
                    {
                        return ncell;
                    }
                  
                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.row < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(this.row + 1, this.col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
                    {
                        return ncell;
                    }
                }
            }
            return this; // if can not return next cell return its own reference
        }
        public GameCell nextBulletCell(GameDirection direction)
        {
            // int score = 0;
            if (direction == GameDirection.Left)
            {
                if (this.col > 0)
                {
                    GameCell ncell = grid.getCell(row, col - 1);
                    return ncell;

                }
            }

            if (direction == GameDirection.Right)
            {
                if (this.col < grid.Cols - 1)
                {
                    GameCell ncell = grid.getCell(this.row, this.col + 1);
                    return ncell;

                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.row > 0)
                {
                    GameCell ncell = grid.getCell(this.row - 1, this.col);
                    return ncell;

                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.row < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(this.row + 1, this.col);
                    return ncell;
                }
            }
            return this; // if can not return next cell return its own reference
        }
        public int X { get => row; set => row = value; }
        public int Y { get => col; set => col = value; }
        public GameObject CurrentGameObject { get => currentGameObject; }
        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
        public static int Score { get => score; set => score = value; }
        // public int Score { get => score; set => score = value; }
    }
}
