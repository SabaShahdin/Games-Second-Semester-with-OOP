using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace game
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

      
    }
}
