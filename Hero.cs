using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class Hero : BaseCharacterClass
    {
        public int currentFrame;
        public int jumpSpeed;

        public bool isMovingRight;
        public bool isMovingLeft;
        public bool isJumping;
        public bool isFalling;
        public bool isFire;
        public bool turnedLeft;

        public Image heroWalk;
        public Image heroIdle;
        public List<Image> WalkRightAnimation;
        public List<Image> WalkLeftAnimation;
        public List<Image> AttackRightAnimation;
        public List<Image> AttackLeftAnimation;
        public List<Image> IdleRightAnimation;
        public List<Image> IdleLeftAnimation;
        public List<Image> DeathAnimation;

        public Hero(int PosX, int PosY, int heroWidth, int heroHeight)
        {
            posX = PosX;
            posY = PosY;
            this.characterWidth = heroWidth;
            this.characterHeight = heroHeight;
            jumpSpeed = heroHeight / 5 * 4;
            fallSpeed = 0;
            maxJumpOrFallSpeed = heroHeight - 1;
            dirX = heroWidth / 4;
            turnedLeft = false;
            currentFrame = 0;
            WalkLeftAnimation = new List<Image>();
            Image = new Bitmap(Properties.Resources._1, new Size(heroWidth, heroHeight));
            WalkRightAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Walk1, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk2, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk3, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk4, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk5, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk6, new Size(heroWidth, heroHeight)),
            };

            WalkLeftAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Walk7, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk8, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk9, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk10, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk11, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Walk12, new Size(heroWidth, heroHeight)),
            };
            AttackRightAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Attack1, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack2, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack3, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack4, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack5, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack6, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack7, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack8, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack9, new Size(heroWidth, heroHeight)),
            };
            AttackLeftAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Attack10, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack11, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack12, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack13, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack14, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack15, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack16, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack17, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Attack18, new Size(heroWidth, heroHeight)),
            };
            IdleRightAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Idle1, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle2, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle3, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle4, new Size(heroWidth, heroHeight)),
            };
            IdleLeftAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Idle5, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle6, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle7, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Idle8, new Size(heroWidth, heroHeight)),
            };
            DeathAnimation = new List<Image>
            {
                new Bitmap(Properties.Resources.Death1, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Death2, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Death3, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Death4, new Size(heroWidth, heroHeight)),
                new Bitmap(Properties.Resources.Death5, new Size(heroWidth, heroHeight)),
            };  
        }

        public bool CheckCollisionUp(Map level)
        {
            return (level.maps[level.currentLevel][(posY) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] == 9);
        }

        public bool CheckVoidDown(Map level)
        {
            return (level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX) / level.Tile.Width] != 9 &&
                level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX + Image.Width) / level.Tile.Width] != 9 && !isJumping);
        }

        public void Joke(Map level)
        {
            if(level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] == 8)
            {
                level.maps[level.currentLevel][(posY + Image.Height) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] = 1;
            }
        }

        public void Fire(List<Bullet> bullets)
        {
            isFire = true;
            if (!turnedLeft)
                bullets.Add(new Bullet(posX + Image.Width, posY + Image.Height / 2, Image.Width / 10, Image.Height / 10, true, characterWidth));
            else bullets.Add(new Bullet(posX, posY + Image.Height / 2, Image.Width / 10, Image.Height / 10, false, characterWidth));
        }
        public void Jump(Map map)
        {
            posY -= jumpSpeed;
            jumpSpeed -= characterHeight / 6;
            if (Math.Abs(jumpSpeed) >= maxJumpOrFallSpeed) jumpSpeed = -maxJumpOrFallSpeed;
            if (CheckCollisionDown(map))
            {
                isJumping = false;
                jumpSpeed = characterHeight / 5 * 4;
                posY = (posY + Image.Height) / map.Tile.Height * map.Tile.Height - map.Tile.Height;
            }
            if (CheckCollisionUp(map))
            {
                jumpSpeed = 0;
                posY = (posY + Image.Height) / map.Tile.Height * map.Tile.Height + map.Tile.Height;
            }
        }

        public void PlayAnimation(Graphics g)
        {
            if (isFire)
            {
                if (!turnedLeft)
                {
                    g.DrawImage(AttackRightAnimation[currentFrame], new Point(posX, posY));
                    currentFrame++;
                    if (currentFrame == AttackRightAnimation.Count)
                    {
                        currentFrame = 0;
                        isFire = false;
                    }
                }
                if (turnedLeft)
                {
                    g.DrawImage(AttackLeftAnimation[currentFrame], new Point(posX, posY));
                    currentFrame++;
                    if (currentFrame == AttackRightAnimation.Count)
                    {
                        currentFrame = 0;
                        isFire = false;
                    }
                }
            }

            if (isMovingRight && !isFire)
            {
                g.DrawImage(WalkRightAnimation[currentFrame], new Point(posX, posY));
                currentFrame++;
                if (currentFrame == WalkRightAnimation.Count) currentFrame = 0;
            }

            if (isMovingLeft && !isFire)
            {

                g.DrawImage(WalkLeftAnimation[currentFrame], new Point(posX, posY));
                currentFrame++;
                if (currentFrame == WalkRightAnimation.Count) currentFrame = 0;
            }

            if(!isMovingRight && !isMovingLeft && !isFire)
            {
                if (turnedLeft)
                {
                    g.DrawImage(IdleLeftAnimation[currentFrame], new Point(posX, posY));
                    currentFrame++;
                    if (currentFrame == IdleLeftAnimation.Count) currentFrame = 0;
                }
                if(!turnedLeft)
                {
                    g.DrawImage(IdleRightAnimation[currentFrame], new Point(posX, posY));
                    currentFrame++;
                    if (currentFrame == IdleRightAnimation.Count) currentFrame = 0;
                }

            }


            
        }

        public bool CheckDeath(List<Enemy> enemies)
        {
            if(enemies.Count > 0)
            {
                for(var i = 0; i < enemies.Count; i++)
                {
                    if ((posX + Image.Width >= enemies[i].posX && posX <= enemies[i].posX + enemies[i].Image.Width) && (posY + Image.Height >= enemies[i].posY && posY <= enemies[i].posY + enemies[i].Image.Height))
                        return true;
                }
            }

            return false;
        }

        public void GoNextLevel(Map level, List<Bullet> bullets, List<Enemy> enemies)
        {
            if (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] == 2)
            {
                level.enemiesIsInitialized = false;
                bullets.Clear();
                enemies.Clear();
                level.currentLevel++;
            }
        }

        public void FinishGame(Map level, List<Bullet> bullets, List<Enemy> enemies, Level level1)
        {
            if (level.maps[level.currentLevel][(posY + Image.Height / 2) / level.Tile.Height, (posX + Image.Width / 2) / level.Tile.Width] == 3)
            {
                bullets.Clear();
                enemies.Clear();
                level1.timer.Stop();
                Button exit = new Button();
                exit.Size = new Size(level1.Width / 8, level1.Height / 8);
                exit.Location = new Point(level1.width / 2 - exit.Size.Width / 2, level1.height / 2);
                exit.Text = "Выйти";
                exit.Click += (sender, args) =>
                {
                    Application.Exit();
                };
                level1.Controls.Add(exit);

                Button menu = new Button();
                level1.gameFinish = true;
            }
        }
    }
}
