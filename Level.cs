using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public partial class Level : Form
    {
        public bool keyEIsPressed;
        public bool gameFinish;
        public int width;
        public int height;
        public Timer timer;
        public Game game;
        
        public Level(int width, int height)
        {
            InitializeComponent();
            SetClientSizeCore(width, height);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            gameFinish = false;
            this.width = width;
            this.height = height;

            game = new Game(width, height, this);

            timer = new Timer() { Interval = 50 };
            timer.Tick += new EventHandler(Update);
            timer.Start();

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            FormClosing += Level1_FormClosing;
        }

        private void Level1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            game.PressButton(sender, e, this);
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            game.RaiseButton(sender, e, this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
        }

        public void Update(object sender, EventArgs e)
        {
            game.Update();
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            game.map.CreateMap(g, game.map.maps, game.map.currentLevel, game.enemies, game.hero);
            //g.DrawImage(game.hero.Image, new Point(game.hero.posX, game.hero.posY));
            game.hero.PlayAnimation(g);
            game.DrawEnemies(g);
            game.DrawBullets(g);
            if(gameFinish == true)
            {
                var image = new Bitmap(Properties.Resources.EndGame, new Size(width / 2, height / 2));
                g.DrawImage(image, new Point(width / 2 - image.Size.Width / 2, height / 2 - image.Size.Height / 2));
            }
            
        }
    }
}
