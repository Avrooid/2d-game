using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Menu : Form
    {
        readonly Size defaultSize = new Size(100, 50);
        public Menu()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;

            //PictureBox controlInf = new PictureBox();
            //controlInf.Location = new Point(0, 0);
            //controlInf.Size = new Size(ClientSize.Width - defaultSize.Width, ClientSize.Height);
            //controlInf.BackgroundImage = new Bitmap(Properties.Resources.Control, new Size(controlInf.Width, controlInf.Height));
            ////controlInf.Visible = false;
            ////Controls.Add(controlInf);

            //PictureBox plotInf = new PictureBox();
            //plotInf.Location = new Point(0, 0);
            //plotInf.Size = new Size(ClientSize.Width - defaultSize.Width, ClientSize.Height);
            //controlInf.BackgroundImage = new Bitmap(Properties.Resources.Plot, new Size(plotInf.Width, controlInf.Height));
            ////plotInf.Visible = false;
            ////Controls.Add(plotInf);

            Button play = new Button();
            play.Text = "Играть";
            play.Click += (sender, args) =>
            {
                bool create = false;

                foreach(Form form in Application.OpenForms)
                {
                    if(form.Name.ToString() == "Level1")
                    {
                        this.Hide();
                        form.Visible = true;
                        create = true;
                        break;
                    }
                }

                if(create == false)
                {
                    Level level1 = new Level(ClientSize.Width, ClientSize.Height);
                    this.Hide();
                    level1.Show();
                }
            };
            Controls.Add(play);

            Button quit = new Button();
            quit.Text = "Выйти";
            quit.Click += (sender, args) =>
            {
                Close(); 
            };
            Controls.Add(quit);

            

            Button control = new Button();
            control.Text = "Управление";
            Controls.Add(control);

            Button plot = new Button();
            plot.Text = "Сюжет";
            Controls.Add(plot);

            //Button back = new Button();
            //back.Text = "Назад";
            //back.Size = defaultSize;
            //back.Location = new Point(ClientSize.Width - defaultSize.Width, (ClientSize.Height - defaultSize.Height) / 2);
            //back.Visible = false;
            //Controls.Add(back);
            //back.Click += (sender, args) =>
            //{
            //    play.Visible = true;
            //    control.Visible = true;
            //    quit.Visible = true;
            //    plot.Visible = true;
                
                
            //};


            control.Click += (sender, args) =>
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                play.Visible = false;
                control.Visible = false;
                quit.Visible = false;
                plot.Visible = false;
                var controlInf = new PictureBox();
                controlInf.Location = new Point(0, 0);
                controlInf.Size = new Size(ClientSize.Width - defaultSize.Width, ClientSize.Height);
                controlInf.BackgroundImage = new Bitmap(Properties.Resources.Control, new Size(controlInf.Width, controlInf.Height));
                Controls.Add(controlInf);
                Button back = new Button();
                back.Text = "Назад";
                back.Size = defaultSize;
                back.Location = new Point(ClientSize.Width - defaultSize.Width, (ClientSize.Height - defaultSize.Height) / 2);
                back.Click += (sender, args) =>
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    this.MaximizeBox = true;
                    play.Visible = true;
                    control.Visible = true;
                    quit.Visible = true;
                    plot.Visible = true;
                    Controls.Remove(controlInf);
                    Controls.Remove(back);
                };
                Controls.Add(back);
            };

            plot.Click += (sender, args) =>
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                play.Visible = false;
                control.Visible = false;
                quit.Visible = false;
                plot.Visible = false;
                var plotInf = new PictureBox();
                plotInf.Location = new Point(0, 0);
                plotInf.Size = new Size(ClientSize.Width - defaultSize.Width, ClientSize.Height);
                plotInf.BackgroundImage = new Bitmap(Properties.Resources.Plot, new Size(plotInf.Width, plotInf.Height));
                Controls.Add(plotInf);
                Button back = new Button();
                back.Text = "Назад";
                back.Size = defaultSize;
                back.Location = new Point(ClientSize.Width - defaultSize.Width, (ClientSize.Height - defaultSize.Height) / 2);
                back.Click += (sender, args) =>
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    this.MaximizeBox = true;
                    play.Visible = true;
                    control.Visible = true;
                    quit.Visible = true;
                    plot.Visible = true;
                    Controls.Remove(plotInf);
                    Controls.Remove(back);
                };
                Controls.Add(back);
            };
            



            SizeChanged += (sender, args) =>
            {
                play.Location = new Point(ClientSize.Width / 2 - 50, ClientSize.Height / 2 - 25);
                play.Size = defaultSize;

                control.Location = new Point(ClientSize.Width / 2 - 50, play.Bottom);
                control.Size = defaultSize;

                plot.Location = new Point(ClientSize.Width / 2 - 50, control.Bottom);
                plot.Size = defaultSize;

                quit.Location = new Point(ClientSize.Width / 2 - 50, plot.Bottom);
                quit.Size = defaultSize;
            };

            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
        }

    }
}
