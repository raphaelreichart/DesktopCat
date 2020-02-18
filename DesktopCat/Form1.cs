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
        static internal Cat Cat;

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
            this.TopMost = true;
            pictureBox1.Visible = true;
            Cat = new Cat(this.pictureBox1, this);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Cat.Move();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
