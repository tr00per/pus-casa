using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PO1
{
    public partial class geometryczne : UserControl
    {
        public geometryczne()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja pobierająca obraz z aktywnego okna. 
        /// Wywoływana jest przy zmianie aktywnego okna w programie.
        /// </summary>
        public void getBitmap()
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                bmp = ((Form2)this.ParentForm.ActiveMdiChild).getChanged();
                this.resizeBarPoziom.Value = 100;
                this.resizeTextPoziom.Text = "100%";
            }
        }


        /// <summary>
        /// Funkcja odbijająca obraz w poziomie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odbiciePoziome_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
               ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
            }
        }

        /// <summary>
        /// Funkcja odbijająca obraz w pionie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odbiciePion_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
            }
        }

        /// <summary>
        /// Funkcja odbijająca obraz po skosie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OdbicieSkos_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
            }
        }

        /// <summary>
        /// Zmiana rozmiaru obrazka zgodnie z parametrami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resizeButton_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                float poziom = (float)(this.resizeBarPoziom.Value) / 100;
                float pion = (float)(-this.resizeBarPion.Value) / 100;

                int nWidth = (int)(bmp.Width * poziom);
                int nHeight = (int)(bmp.Height * pion);

                Bitmap outputBitmap = new Bitmap(nWidth, nHeight);

                Graphics g = Graphics.FromImage((Image)outputBitmap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, 0, 0, nWidth, nHeight);
                g.Dispose();

                bmp = outputBitmap;

                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);

            }
            
        }

        /// <summary>
        /// Funkcja modyfikująca wartość wyświetlaną w textBoxie pod ResizeBarem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resizeBarPoziom_ValueChanged(object sender, EventArgs e)
        {
            this.resizeTextPoziom.Text = this.resizeBarPoziom.Value.ToString() + "%";
            if (this.ResizeZlaczone.Checked)
            {
                this.resizeTextPion.Text = (-this.resizeBarPion.Value).ToString() + "%";
                this.resizeBarPion.Value = -this.resizeBarPoziom.Value;
            }
        }

        /// <summary>
        /// Funkcja modyfikująca wartość wyświetlaną w textBoxie pod ResizeBarem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resizeBarPion_ValueChanged(object sender, EventArgs e)
        {
            this.resizeTextPion.Text = (-this.resizeBarPion.Value).ToString() + "%";
            if (this.ResizeZlaczone.Checked)
            {
                this.resizeTextPoziom.Text = this.resizeBarPoziom.Value.ToString() + "%";
                this.resizeBarPoziom.Value = -this.resizeBarPion.Value;
            }
        }

        /// <summary>
        /// Funkcja wyrównująca wartości skalowania po kliknięciu zachowania proporcji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeZlaczone_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ResizeZlaczone.Checked)
            {
                this.resizeTextPoziom.Text = this.resizeBarPoziom.Value.ToString() + "%";
                this.resizeBarPoziom.Value = -this.resizeBarPion.Value;
            }
        }


    }
}
