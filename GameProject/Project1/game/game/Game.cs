using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace game
{
    public class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, game.Properties.Resources.Field);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = game.Properties.Resources.Field;
            if (displayCharacter == '|' || displayCharacter == '_')
            {
                img = game.Properties.Resources.Rocks;
            }
            if (displayCharacter == '#')
            {
                img = game.Properties.Resources.Rocks;
               
            }
            if (displayCharacter == '/')
            {
                img = game.Properties.Resources.lINESS__2_;

            }
            if (displayCharacter == '\\')
            {
                img = game.Properties.Resources.Slant;

            }
            if (displayCharacter == '>')
            {
                img = game.Properties.Resources.Medal;
            }
            if (displayCharacter == '@')
            {
                img = game.Properties.Resources.rock_icon_14;
            }
            if (displayCharacter == '$')
            {
                img = game.Properties.Resources.Score;
            }
            if (displayCharacter == 'P' )
            {
                img = game.Properties.Resources.PlayerBall;
            }            
            if (displayCharacter == '^')
            {
                img = game.Properties.Resources.Bonus;
            }
            if (displayCharacter == '*')
            {
                img = game.Properties.Resources.wine;
            }
            if (displayCharacter == 'H')
            {
                img = game.Properties.Resources.HorizontalGhost;
            }
            if (displayCharacter == 'V')
            {
                img = game.Properties.Resources.VerticalGhost;
            }
            if (displayCharacter == 'v')
            {
                img = game.Properties.Resources.GoalKeeper;
            }
            if (displayCharacter == 'R')
            {
                img = game.Properties.Resources.Random;
            }
            if (displayCharacter == '-')
            {
                img = game.Properties.Resources.laserRed12;
            }
            if (displayCharacter == '&')
            {
                img = game.Properties.Resources.laserBlue12;
            }
            if (displayCharacter == 'A')
            {
                img = game.Properties.Resources.laserRed16;
            }
            if (displayCharacter == 'B')
            {
                img = game.Properties.Resources.laserBlue16;
            }

            return img;
        }
    }
}
