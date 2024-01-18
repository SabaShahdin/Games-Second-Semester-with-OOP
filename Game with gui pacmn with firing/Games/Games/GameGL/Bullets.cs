using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Games.GameGL
{
    public class Bullet : GameObject
    {
        private GameDirection direction;
        private bool isActive;

        public Bullet(GameCell startCell, GameDirection direction, Image image) : base(GameObjectType.BULLET, image)
        {
            this.CurrentCell = startCell;
            this.direction = direction;
            this.isActive = true;
        }

        public GameDirection Direction { get => direction; set => direction = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        /* public void Move(GameCell playerCurrentCell)
          {
              GameCell currentCell = this.CurrentCell;
              GameCell nextCell = currentCell.nextBulletCell(this.Direction);

              if (nextCell != currentCell)
              {
                  if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                  {
                      if (nextCell != playerCurrentCell)
                      {
                          currentCell.setGameObject(Game.getBlankGameObject());
                          this.CurrentCell = nextCell;
                          if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                          {
                              nextCell.setGameObject(this);
                              this.CurrentCell = nextCell;
                          }
                          else
                          {
                              this.IsActive = false;
                          }
                      }
                      else
                      {
                          this.IsActive = false;
                      }
                  }
                  else
                  {
                      this.IsActive = false;
                  }
              }
              else
              {
                  this.IsActive = false;
              }
          }*/

        /* public void Move(GameCell playerCurrentCell)
         {
             GameCell currentCell = this.CurrentCell;
             GameCell nextCell = currentCell.nextBulletCell(this.Direction);

             if (nextCell != currentCell)
             {
                 if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                 {
                     if (nextCell != playerCurrentCell)
                     {
                         currentCell.setGameObject(Game.getBlankGameObject());
                         this.CurrentCell = nextCell;
                         if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                         {
                             nextCell.setGameObject(this);
                             this.CurrentCell = nextCell;
                         }
                         else
                         {
                             this.IsActive = false;
                         }
                     }
                     else
                     {
                         this.IsActive = false;
                     }
                 }
                 else 
                 {
                     if (Collision.CheckCollision(nextCell))
                     {
                         if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
                         {
                             bulletImage = Game.getGameObjectImage('+');

                         }
                     }

                 }
             }
             else
             {
                 this.IsActive = false;
             }
         }*/
        public void Move(GameCell playerCurrentCell)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextBulletCell(this.Direction);
            if (nextCell != currentCell)
            {
                 if (nextCell != playerCurrentCell)
                 {
                     currentCell.setGameObject(Game.getBlankGameObject());
                     this.CurrentCell = nextCell;
                     if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                     {
                        nextCell.setGameObject(this);
                        this.CurrentCell = nextCell;
                     }
                     else
                     {
                            this.IsActive = false;
                     }
                 }
            }
           else
           {
                this.IsActive = false;
           }

        }

    }

}
