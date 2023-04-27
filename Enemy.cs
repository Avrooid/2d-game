using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Game
{
    public class Enemy : BaseCharacterClass
    {
        public bool isMovingRight;

        public Enemy(int PosX, int PosY, int heroWidth, int heroHeight)
        {
            characterWidth = heroWidth;
            characterHeight = heroHeight;
            posX = PosX;
            posY = PosY;
            dirX = heroWidth / 3;
            fallSpeed = 0;
            maxJumpOrFallSpeed = heroHeight - 1;
            Image = new Bitmap(Properties.Resources.Enemy1, new Size(heroWidth, heroHeight));
        }

        public void Move(Hero hero, Map map)
        {
            var dif = GetCoordinateDifference(hero);
            if(Math.Abs(dif.Item2) < characterHeight * 2)
            {
                if (dif.Item1 > 0)
                    MoveRight(map);
                else MoveLeft(map);
            }
        }

        public bool CheckVoidDown(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX) / level.Tile.Width] != 9 &&
                level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX + Image.Width) / level.Tile.Width] != 9);
        }

        public Tuple<int, int> GetCoordinateDifference(Hero hero)
        {
            return Tuple.Create(hero.posX - posX, hero.posY - posY);
        }
    }
}
