using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace game
{
    public class GamePlayer : GameObject
    {
        public GamePlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }
      
        public void move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (nextCell != currentCell && nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType != GameObjectType.BOUNDARY)
            {
                if (Collision.CheckCollision(nextCell))
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.SCORE)
                    {
                        QatarFifa.Scoring();
                        nextCell.setGameObject(Game.getBlankGameObject());
                    }
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.BONUS)
                    {
                        QatarFifa.bonus();
                        nextCell.setGameObject(Game.getBlankGameObject());
                    }
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENERGY)
                    {
                        QatarFifa.energize();
                        nextCell.setGameObject(Game.getBlankGameObject());
                    }
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        QatarFifa.DecreaseHealth();
                    }
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMYBULLET)
                    {
                        QatarFifa.DecreaseHealth();
                    }
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WIN)
                    {

                        Form form = new WinForm();
                        form.Show();
                    }

                }

                this.CurrentCell = nextCell;
                currentCell.setGameObject(Game.getBlankGameObject());
            }
        }
    }
}
