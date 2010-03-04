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
                Reload();
            }
        }

        private void Reload()
        {
            this.podstawowe1.getBitmap();
            this.geometryczne1.getBitmap();
            this.filtr_alfa_obciety1.getBitmap();
            this.filtr_kontr_harmoniczny1.getBitmap();
        }

        public void Przepisz()
        {
            this.miary_podobienstwa1.compute();
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                Reload();
                this.miary_podobienstwa1.Activate();
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            ((Form2)this.ActiveMdiChild).getChanged().Save(fs,
                               System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            ((Form2)this.ActiveMdiChild).getChanged().Save(fs,
                               System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            ((Form2)this.ActiveMdiChild).getChanged().Save(fs,
                               System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }

                    fs.Close();
                }
            }

        }

        private void operacjePodstawoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableMenus();
            this.podstawowe1.Enabled = true;
            this.podstawowe1.Visible = true;
            Reload();
        }


        private void DisableMenus()
        {
            this.podstawowe1.Enabled = false;
            this.geometryczne1.Enabled = false;
            this.filtr_alfa_obciety1.Enabled = false;
            this.filtr_kontr_harmoniczny1.Enabled = false;
            this.podstawowe1.Visible = false;
            this.geometryczne1.Visible = false;
            this.filtr_alfa_obciety1.Visible = false;
            this.filtr_kontr_harmoniczny1.Visible = false;
        }

        private void operacjeGeometryczneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableMenus();
            this.geometryczne1.Enabled = true;
            this.geometryczne1.Visible = true;
            Reload();
        }


        private void ącyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableMenus();
            this.filtr_alfa_obciety1.Enabled = true;
            this.filtr_alfa_obciety1.Visible = true;
            Reload();
        }

        private void filtrKontrharmonicznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableMenus();
            this.filtr_kontr_harmoniczny1.Enabled = true;
            this.filtr_kontr_harmoniczny1.Visible = true;
            Reload();
        }

        private void analizaPodobieństwaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool c = !this.analizaPodobieństwaToolStripMenuItem.Checked;

            this.miary_podobienstwa1.Enabled = c;
            this.miary_podobienstwa1.Visible = c;
            this.analizaPodobieństwaToolStripMenuItem.Checked = c;
        }


    }

    
}
