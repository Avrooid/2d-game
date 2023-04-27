using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game
{
    public class BaseCharacterClass
    {
        public int posX;
        public int posY;
        public int dirX;
        public int dirY;
        public int fallSpeed;
        public int maxJumpOrFallSpeed;
        public int characterWidth;
        public int characterHeight;
        public Image Image;

        public BaseCharacterClass()
        {
           
        }

        public bool CheckCollisionRight(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX + Image.Width) / level.Tile.Width] == 9);
        }

        public bool CheckCollisionLeft(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX) / level.Tile.Width] == 9);
        }

        public bool CheckCollisionDown(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] == 9);
        }

        public void MoveRight(Map map)
        {
            posX += dirX;
            if (CheckCollisionRight(map))
                posX = (posX + Image.Width) / map.Tile.Width * map.Tile.Width - map.Tile.Width;
        }

        public void MoveLeft(Map map)
        {
            posX -= dirX;
            if (CheckCollisionLeft(map))
                posX = (posX + Image.Width) / map.Tile.Width * map.Tile.Width;
        }

        public void Fall(Map map)
        {
            posY -= fallSpeed;
            fallSpeed -= characterHeight / 6;
            if (Math.Abs(fallSpeed) >= maxJumpOrFallSpeed) fallSpeed = -maxJumpOrFallSpeed;
            if (CheckCollisionDown(map))
            {
                fallSpeed = 0;
                posY = (posY + Image.Height) / map.Tile.Height * map.Tile.Height - map.Tile.Height;
            }
        }
    }
}
