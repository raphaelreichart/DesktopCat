using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCat
{
    class Cat
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle rect);

        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        private int speedX = -5;
        private int speedY = 0;

        private bool followCursor = false;
        private bool pullNotepadLeft = false;
        private bool pullNotepadRight = false;
        public bool pullWindowRight = false;
        public bool pullWindowLeft = false;

        private PictureBox pictureBox;
        private Form form;
        public Form2 memeImages;
        private Random rand;

        public Cat(PictureBox pictureBox,  Form form)
        {
            this.pictureBox = pictureBox;
            this.form = form;
            this.rand = new Random();
        }



        public void Move()
        {
            if (pullWindowRight)
            {

                if (memeImages == null)
                {
                    if (form.Left >= Screen.PrimaryScreen.Bounds.Width + 200)
                    {
                        memeImages = new Form2();
                        memeImages.Visible = false;
                        memeImages.Width = 400;
                        memeImages.Height = 400;
                        if (form.Top <= 400)
                        {
                            form.Top = 600;
                        }
                        else if (form.Top >= Screen.PrimaryScreen.Bounds.Width - 400)
                        {
                            form.Top = 600;
                        }
                        memeImages.Left = Screen.PrimaryScreen.Bounds.Width + 600;
                        memeImages.Top = form.Top + memeImages.Height / 2;
                        pictureBox.Image = DesktopCat.Properties.Resources.cat_right_back;
                        memeImages.Show();
                    }
                    else
                    {
                        form.Left += 5;
                    }
                }
                else
                {
                    if (form.Left <= Screen.PrimaryScreen.Bounds.Width - 550)
                    {
                        pullWindowRight = false;
                        memeImages = null;
                        pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                    }
                    else
                    {
                        memeImages.Visible = true;
                        memeImages.Left = form.Left + form.Width;
                        memeImages.Top = form.Top - memeImages.Height / 2;
                        form.Left -= 5;
                    }
                }
                return;
            }
            if (pullWindowLeft)
            {
                if(memeImages == null)
                {
                    if (form.Left <= -200)
                    {
                        memeImages = new Form2();
                        memeImages.Visible = false;
                        memeImages.Width = 400;
                        memeImages.Height = 400;
                        if(form.Top <= 400)
                        {
                            form.Top = 600;
                        }else if(form.Top >= Screen.PrimaryScreen.Bounds.Width - 400)
                        {
                            form.Top = 600;
                        }
                        memeImages.Left = -600;
                        memeImages.Top = form.Top + memeImages.Height/2;
                        pictureBox.Image = DesktopCat.Properties.Resources.cat_left_back;
                        memeImages.Show();
                    }
                    else
                    {
                        form.Left -= 5;
                    }
                }
                else
                {
                    if(form.Left >= 450)
                    {
                        pullWindowLeft = false;
                        memeImages = null;
                        pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                    }
                    else
                    {
                        memeImages.Visible = true;
                        memeImages.Left = form.Left-memeImages.Width + 25;
                        memeImages.Top = form.Top - memeImages.Height / 2;
                        form.Left += 5;
                    }
                }
                return;
            }
            if (this.form.Left <= 0)
            {
                pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_right;
                speedX *= -1;
                speedY = rand.Next(0, 7) - 3;
            }
            else if (this.form.Left + pictureBox.Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                speedX *= -1;
                speedY = rand.Next(0, 7) - 3;
            }

            if (this.form.Top <= 0)
            {
                speedY = rand.Next(0, 7) - 3;
                speedY *= -1;
            }
            else if (this.form.Top + this.form.Height >= Screen.PrimaryScreen.Bounds.Width)
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
                        pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                    }
                    else
                    {
                        pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_right;
                    }
                }else if(rand.NextDouble() < 0.05)
                {
                    pullWindowLeft = true;
                    pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_left;
                }
                else if (rand.NextDouble() < 0.05)
                {
                    pullWindowRight = true;
                    pictureBox.Image = DesktopCat.Properties.Resources.walking_cat_drawing_right;
                }
                speedY = rand.Next(0, 7) - 3;
            }
            this.form.Left += speedX;
            this.form.Top += speedY;
        }

    }
}
