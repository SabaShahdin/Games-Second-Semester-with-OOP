using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace game
{
    public abstract class Defender : GameObject
    {
        GameDirection currentDirection;
        public GameDirection CurrentDirection { get => currentDirection; set => currentDirection = value; }

        public Defender(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
        }
        public Defender(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
        }
        public abstract GameCell Move();
    }
}
