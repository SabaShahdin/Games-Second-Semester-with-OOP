using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace game
{
    public class GameObject
    {
        char displayCharacter;
        GameObjectType gameObjectType;
        GameCell currentCell;
        Image image;
        public GameObject(GameObjectType type, Image image)
        {
            this.GameObjectType = type;
            this.Image = image;
        }
        public GameObject(GameObjectType type, char displayCharacter)
        {
            this.GameObjectType = type;
            this.DisplayCharacter = displayCharacter;
        }

        public static GameObjectType getGameObjectType(char displayCharacter)
        {

            if (displayCharacter == '_' || displayCharacter == '@')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '|')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '#')
            {
                return GameObjectType.BOUNDARY;
            }
            if (displayCharacter == '>')
            {
                return GameObjectType.SCORE;
            }
            if (displayCharacter == '$')
            {
                return GameObjectType.ENERGY;
            }
            if (displayCharacter == 'P')
            {
                return GameObjectType.PLAYER;
            }
            if (displayCharacter == '*')
            {
                return GameObjectType.WIN;
            }
            if (displayCharacter == '^')
            {
                return GameObjectType.BONUS;
            }
            if (displayCharacter == 'H')
            {
                return GameObjectType.ENEMY;
            }
            if (displayCharacter == 'V')
            {
                return GameObjectType.ENEMY;

            }
            if (displayCharacter == 'v')
            {
                return GameObjectType.ENEMY;

            }
            if (displayCharacter == 'R')
            {
                return GameObjectType.ENEMY;

            }
            if (displayCharacter == '-')
            {
                return GameObjectType.BULLET;

            }
            if (displayCharacter == '&')
            {
                return GameObjectType.BULLET;

            }
            if (displayCharacter == 'A')
            {
                return GameObjectType.ENEMYBULLET;

            }
            if (displayCharacter == 'B')
            {
                return GameObjectType.ENEMYBULLET;

            }

            return GameObjectType.NONE;
            
        }
     
        public GameCell CurrentCell
        {
            get => CurrentCell1;
            set
            {
                CurrentCell1 = value;
                CurrentCell1.setGameObject(this);
            }
        }

        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell1 { get => currentCell; set => currentCell = value; }
        public Image Image { get => image; set => image = value; }
    }
}
