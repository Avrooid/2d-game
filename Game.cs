using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class Game
    {
        public Hero hero;
        public Map map;
        public List<Enemy> enemies;
        public List<Bullet> bullets;
        public Level level;

        public Game(int width, int height, Level level)
        {
            map = new Map(width, height);
            var blockWidth = width / map.map1.GetLength(1);
            var blockHeight = height / map.map1.GetLength(0);
            hero = new Hero(blockWidth * 7, blockHeight * 12, blockWidth, blockHeight);
            enemies = new List<Enemy>();
            bullets = new List<Bullet>();
            this.level = level;
        }

        public void Update()
        {
            if (hero.isMovingRight)
            {
                hero.turnedLeft = false;
                hero.MoveRight(map);
            }
            if (hero.isMovingLeft)
            {
                hero.turnedLeft = true;
                hero.MoveLeft(map);
            }
            if (hero.isJumping)
                hero.Jump(map);
            if (hero.CheckVoidDown(map))
                hero.Fall(map);
            if (hero.CheckDeath(enemies))
                map.RestartLevel1(bullets, enemies);
            hero.Joke(map);
            hero.FinishGame(map, bullets, enemies, level);
            hero.GoNextLevel(map, bullets, enemies);

            if (enemies.Count > 0)
            {
                for (var i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Move(hero, map);
                    if (enemies[i].CheckVoidDown(map))
                        enemies[i].Fall(map);
                }
            }
            if (bullets.Count > 0)
            {
                for (var i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].isMovingRight)
                    {
                        bullets[i].MoveRight();
                        if (bullets[i].CheckCollisionRight(map))
                            bullets.Remove(bullets[i]);
                    }

                    else
                    {
                        bullets[i].MoveLeft();
                        if (bullets[i].CheckCollisionLeft(map))
                            bullets.Remove(bullets[i]);
                    }
                }
            }
            if (bullets.Count > 0)
            {
                for (var j = 0; j < bullets.Count; j++)
                {
                    var a = bullets[j].CheckHit(enemies);
                    if (a.Item1)
                    {
                        bullets.Remove(bullets[j]);
                        enemies.Remove(enemies[a.Item2]);
                    }
                }
            }
        }

        public void PressButton(object sender, KeyEventArgs e, Level level)
        {
            if (e.KeyCode == Keys.D)
            {
                if(!hero.isFire)
                    hero.currentFrame = 0;
                hero.isMovingRight = true;
            }
                

            if (e.KeyCode == Keys.A)
            {
                if (!hero.isFire)
                    hero.currentFrame = 0;
                hero.isMovingLeft = true;
            }
                

            if (!hero.isJumping)
            {
                if (e.KeyCode == Keys.Space)
                    hero.isJumping = true;
            }

            if (!hero.isFire)
            {
                if (e.KeyCode == Keys.E)
                {
                    if (!level.keyEIsPressed)
                    {
                        hero.currentFrame = 0;
                        level.keyEIsPressed = true;
                        hero.Fire(bullets);
                    }
                }
            }
        }

        public void RaiseButton(object sender, KeyEventArgs e, Level level)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (!hero.isFire)
                        hero.currentFrame = 0;
                    hero.isMovingRight = false;
                    break;
                case Keys.A:
                    if (!hero.isFire)
                        hero.currentFrame = 0;
                    hero.isMovingLeft = false;
                    break;
                case Keys.E:
                    level.keyEIsPressed = false;
                    break;
            }
        }

        public void DrawEnemies(Graphics g)
        {
            if (enemies.Count > 0)
            {
                foreach (var enemy in enemies)
                    g.DrawImage(enemy.Image, new Point(enemy.posX, enemy.posY));
            }
        }

        public void DrawBullets(Graphics g)
        {
            if (bullets.Count > 0)
            {
                foreach (var bullet in bullets)
                    g.DrawImage(bullet.Image, new Point(bullet.posX, bullet.posY));
            }
        }
    }
}
