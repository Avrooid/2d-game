using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Game
{
    public class Map
    {
        public int[,] map1 = new int[,] 
        { 
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,2,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,9,1,1,9},
                {9,4,4,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,1,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,9,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,4,4,1,1,1,1,5,1,9,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}
        };

        public int[,] map2 = new int[,]
        {
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,2,9},
                {9,9,9,9,9,9,1,1,1,9,9,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,9,9},
                {9,1,1,1,1,1,1,9,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,9,1,1,9,1,9},
                {9,1,4,1,1,1,1,1,1,1,1,1,4,1,9},
                {9,9,9,9,9,1,1,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,9,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,9,1,1,1,1,1,1,1,9},
                {9,1,1,4,1,1,1,1,1,5,1,1,4,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}
        };

        public int[,] map3 = new int[,]
        {
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,4,2,1,1,9},
                {9,1,1,1,9,9,9,9,9,9,9,9,1,1,9},
                {9,9,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,9,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,4,4,1,1,1,1,1,1,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,9,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,5,1,1,4,1,1,4,1,9,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}
        };

        public int[,] map4 = new int[,]
        {
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,9,1,1,1,1,1,1,1,9},
                {9,1,1,9,9,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,9,1,1,1,1,9,9},
                {9,9,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,9,1,1,1,1,1,1,1,1,1,3,1,9},
                {9,1,1,1,9,1,1,1,1,8,1,1,9,1,9},
                {9,1,1,1,1,1,1,5,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,9,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,4,4,4,4,4,4,4,4,4,4,4,4,4,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}
        };

        public int[,] map5 = new int[,]
        {
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,3,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,1,1,1,9,9},
                {9,1,1,1,1,1,1,1,1,1,1,1,9,1,9},
                {9,1,1,1,1,1,1,1,1,1,1,9,1,1,9},
                {9,1,1,4,4,1,1,1,1,5,9,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,1,1,1,1,9},
                {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}
        };

        public Image Tile;
        public Image Door;
        public Image StudTicket;
        readonly int blockWidth;
        readonly int blockHeight;
        public int currentLevel;
        public int[][,] maps;
        public int[][] enemiesStartPositionX;
        public int[][] enemiesStartPositionY;
        public bool enemiesIsInitialized;

        public Map(int width, int height)
        {
            enemiesIsInitialized = false;
            blockWidth = width / map1.GetLength(1);
            blockHeight = height / map1.GetLength(0);
            currentLevel = 0;
            Tile = new Bitmap(Properties.Resources.Tile_02, new Size(blockWidth, blockHeight));
            Door = new Bitmap(Properties.Resources.pngwing_com__1_, new Size(blockWidth, blockHeight));
            StudTicket = new Bitmap(Properties.Resources.student_ticket, new Size(blockWidth, blockHeight));
            maps = new int[][,] { map1, map2, map3, map4, map5 };
            enemiesStartPositionX = new int[5][]
            {
                new int[] {2, 3, 2, 3, 13},
                new int[] {2, 3, 2, 3, 13},
                new int[] {2, 3, 2, 3, 13},
                new int[] {2, 3, 2, 3, 13},
                new int[] {2, 3, 2, 3, 13}
            };
            enemiesStartPositionY = new int[5][]
            {
                new int[] {12, 12, 8, 8, 12},
                new int[] {12, 12, 8, 8, 12},
                new int[] {12, 12, 8, 8, 12},
                new int[] {12, 12, 8, 8, 12},
                new int[] {12, 12, 8, 8, 12}
            };
        }

        public void CreateMap(Graphics g, int[][,] maps, int currentLevel, List<Enemy> enemies, Hero hero)
        {
            for (var y = 0; y < maps[currentLevel].GetLength(0); y++)
                for (var x = 0; x < maps[currentLevel].GetLength(1); x++)
                {
                    if (maps[currentLevel][y, x] == 9 || maps[currentLevel][y, x] == 8)
                    {
                        g.DrawImage(Tile, new PointF(Tile.Width * x, Tile.Height * y));
                    }

                    if(maps[currentLevel][y, x] == 2)
                    {
                        g.DrawImage(Door, new PointF(Door.Width * x, Door.Height * y));
                    }

                    if (maps[currentLevel][y, x] == 3)
                    {
                        g.DrawImage(StudTicket, new PointF(StudTicket.Width * x, StudTicket.Height * y));
                    }
                    if (!enemiesIsInitialized)
                    {
                        if (maps[currentLevel][y, x] == 4)
                        {
                            enemies.Add(new Enemy(blockWidth * x, blockHeight * y, blockWidth, blockHeight));
                        }
                        if (maps[currentLevel][y, x] == 5)
                        {
                            hero.posX = blockWidth * x;
                            hero.posY = blockHeight * y;
                        }
                    }
                }
            enemiesIsInitialized = true;
        }

        public void RestartLevel1(List<Bullet> bullets, List<Enemy> enemies)
        {
            enemiesIsInitialized = false;
            enemies.Clear();
            bullets.Clear();
        }
    }
}
