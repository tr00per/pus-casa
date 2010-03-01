﻿using System;
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
            this.pictureBox1.Image = Image.FromFile(path);
            this.obrazek = new Bitmap(path);
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