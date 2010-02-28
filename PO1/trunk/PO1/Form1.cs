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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 newMDIChild = new Form2(openFileDialog1.FileName);
                
                // Set the Parent Form of the Child window.
                newMDIChild.MdiParent = this;
                // Display the new form.
                newMDIChild.Show();
            }



        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild!=null)
            this.ActiveMdiChild.Close();


        }

        private void zakończToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((Form2)this.ActiveMdiChild).setChanged(new Bitmap(((Form2)this.ActiveMdiChild).getOriginal()));
                this.podstawowe1.getBitmap();
            }
        }
        
        private void podstawowe1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                podstawowe1.getBitmap();
            }
        }


    }

    
}
