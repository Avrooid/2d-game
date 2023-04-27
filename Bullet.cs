using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game
{
    public class Bullet
    {
        public int posX;
        public int posY;
        public int dirX;
        public int dirY;
        public int bulletSpeed;
        public bool isMovingRight;
        

        public Image Image;

        public Bullet(int PosX, int PosY, int bulletWidth, int bulletHeight, bool IsMovingRight, int blockWidth)
        {
            posX = PosX;
            posY = PosY;
            dirX = blockWidth / 2;
            Image = new Bitmap(Properties.Resources.Bullet, new Size(bulletWidth, bulletHeight));
            isMovingRight = IsMovingRight;
        }

        public void MoveRight()
        {
            posX += dirX;
        }

        public void MoveLeft()
        {
            posX -= dirX;
        }

        public bool CheckCollisionRight(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX + Image.Width) / level.Tile.Width] == 9);
        }

        public bool CheckCollisionLeft(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX) / level.Tile.Width] == 9);
        }

        public Tuple<bool, int> CheckHit(List<Enemy> enemies)
        {
            if (enemies.Count > 0)
            {
                for (var i = 0; i < enemies.Count; i++)
                {
                    if ((posX >= enemies[i].posX && posX <= enemies[i].posX + enemies[i].Image.Width) && (posY >= enemies[i].posY && posY <= enemies[i].posY + enemies[i].Image.Height))
                        return Tuple.Create(true, i);
                }
            }

            return Tuple.Create(false, -1);
        }
    }
}
