using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace game
{
    public class RandomDefender : Defender
    {

        public RandomDefender(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
        }
        public int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        public override GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameDirection currentDirection = CurrentDirection;
            GameCell nextCell = currentCell;
            int value = ghostDirection();
            if (value == 0)
            {
                if ((nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER) || nextCell == currentCell)
                {
                    currentDirection = GameDirection.Left;
                    nextCell = currentCell.nextCell(currentDirection);
                    if (Collision.CheckCollision(currentCell))
                    {
                        if (currentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                        {
                            QatarFifa.Scoring();
                        }

                    }
                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                }
            }
            if (value == 1)
            {
                if ((nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER) || nextCell == currentCell)
                {
                    currentDirection = GameDirection.Right;
                    nextCell = currentCell.nextCell(currentDirection);
                    if (Collision.CheckCollision(currentCell))
                    {
                        if (currentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                        {
                            QatarFifa.Scoring();
                        }

                    }
                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                }
            }
            if (value == 2)
            {
                if ((nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER) || nextCell == currentCell)
                {
                    currentDirection = GameDirection.Up;
                    nextCell = currentCell.nextCell(currentDirection);
                    if (Collision.CheckCollision(currentCell))
                    {
                        if (currentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                        {
                            QatarFifa.Scoring();
                        }

                    }
                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                }
            }
            if (value == 3)
            {
                if ((nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER) || nextCell == currentCell)
                {
                    currentDirection = GameDirection.Down;
                    nextCell = currentCell.nextCell(currentDirection);
                    if (Collision.CheckCollision(currentCell))
                    {
                        if (currentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                        {
                            QatarFifa.Scoring();
                        }

                    }
                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.CurrentCell = nextCell;
                }
            }
            return nextCell;
        }
    }
}
