using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PO1
{
    public partial class Form2 : Form
    {
        public Form2(string path)
        {
            InitializeComponent();
            this.Text=path;
            this.obrazek = new Bitmap(path);
            obrazek = obrazek.Clone(new Rectangle(0, 0, obrazek.Width, obrazek.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            this.pictureBox1.Image = new Bitmap(obrazek);
            this.pictureBox2.Image = obrazek;
        }

        public Image getOriginal()
        {
            return this.pictureBox1.Image;
        }

        public Bitmap getChanged()
        {
            return this.obrazek;

        }

        public void setChanged(Bitmap bmp)
        {
            this.obrazek = bmp;
            this.pictureBox2.Image = obrazek;
        }

    }
}
