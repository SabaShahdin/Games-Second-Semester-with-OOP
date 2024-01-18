using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Games.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, Games.Properties.Resources.Field);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = Games.Properties.Resources.Field;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = Games.Properties.Resources.vertical;
            }
            if (displayCharacter == '#')
            {
                img = Games.Properties.Resources.horizontal;
            }         
            if (displayCharacter == 'P' )
            {
                img = Games.Properties.Resources.pacman_open;
            }
            if (displayCharacter == 'o')
            {
                img = Games.Properties.Resources.pacman_close;
            }
            if (displayCharacter == '.' )
            {
                img = Games.Properties.Resources.pallet;
            }
            if (displayCharacter == 'G')
            {
                img = Games.Properties.Resources.ghost_blue;
            }
            if (displayCharacter == '-')
            {
                img = Games.Properties.Resources.laserGreen03;
                    }
            if (displayCharacter == '+')
            {
                img = Games.Properties.Resources.ghost_red;
            }
            return img;
        }
        
    }
}
