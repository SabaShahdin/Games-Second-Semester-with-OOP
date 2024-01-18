using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public static class Collision
    {

        public static bool CheckCollision(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.SCORE || cell.CurrentGameObject.GameObjectType == GameObjectType.BONUS || cell.CurrentGameObject.GameObjectType == GameObjectType.ENERGY || cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY || cell.CurrentGameObject.GameObjectType == GameObjectType.BULLET || cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMYBULLET || cell.CurrentGameObject.GameObjectType == GameObjectType.WIN)
            {
                return true;
            }
            return false;
        }

    }
}
