using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCat
{
    public partial class Form1 : Form
    {
        static int speedX = -5;
        static int speedY = 0;
        static Boolean followCursor = false;
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.pictureBox1.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;
            pictureBox1.Visible = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Left <= 0)
            {
                pictureBox1.Image = DesktopCat.Properties.Resources.walking_cat_drawing_right;
                speedX *= -1;
                speedY = rand.Next(0, 7)-3;
            }
            else if (this.Left + pictureBox1.Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                pictureBox1.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                speedX *= -1;
                speedY = rand.Next(0, 7) - 3;
            }

            if (this.Top <= 0)
            {
                speedY = rand.Next(0, 7) - 3;
                speedY *= -1;
            }
            else if (this.Top + this.Height >= Screen.PrimaryScreen.Bounds.Width)
            {
                speedY = rand.Next(0, 7) - 3;
                speedY *= -1;
            }

            if (rand.NextDouble() < 0.02D)
            {
                if (rand.NextDouble() < 0.05D)
                {
                    speedX *= -1;
                    if (speedX < 0)
                    {
                        pictureBox1.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                    }
                    else
                    {
                        pictureBox1.Image = DesktopCat.Properties.Resources.walking_cat_drawing_right;
                    }
                }
                speedY = rand.Next(0, 7) - 3;
            }
            this.Left += speedX;
            this.Top += speedY;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
