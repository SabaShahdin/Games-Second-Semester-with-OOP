using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace game
{
    public class HorizontalDefender : Defender
    {
        private GameCell initialCell;
        public HorizontalDefender(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
            this.initialCell = startCell;
        }
        public override GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(GameDirection.Right);
            this.CurrentCell = nextCell;
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL || nextCell == currentCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
                this.CurrentCell = this.initialCell;
                nextCell = this.initialCell.nextCell(GameDirection.Left);
            }
            
            else if (currentCell != nextCell)
            {
                if(Collision.CheckCollision(currentCell))
                {
                   if( currentCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                    {
                        QatarFifa.Scoring();
                    }

                }
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
    }
}
