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

    public partial class podstawowe : UserControl
    {
        public podstawowe()
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
                this.jasnoscScroll.Value = 0;
                this.textBox1.Text = "0";
                this.kontrastScroll.Value = 0;
                this.textBox2.Text = "0";
            }
        }

        /// <summary>
        /// Funkcja obsługi kliknięcia przycisku negatywu. Odwraca wartość bitów koloru w pliku
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNegatyw_Click(object sender, EventArgs e)
        {
            this.getBitmap();
             if (this.ParentForm.ActiveMdiChild != null)
            {
               float Mnoznik = (float)(Bitmap.GetPixelFormatSize(bmp.PixelFormat))/8;
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - (int)( bmp.Width * Mnoznik);
                    int nWidth =(int)( bmp.Width * Mnoznik);
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            p[0] = (byte)(255-p[0]);
                            ++p;
                        }
                        p += nOffset;
                    }
                }
                bmp.UnlockBits(bmData);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
                
            }
        }


        /// <summary>
        /// Funkcja aktualizująca wartość suwaka jasności w textBoxie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jasnoscScroll_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = this.jasnoscScroll.Value.ToString();
        }
        
        /// <summary>
        /// Funkcja aktualizująca wartość suwaka kontrastu w textBoxie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kontrastScroll_ValueChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = this.kontrastScroll.Value.ToString();
        }
        
        /// <summary>
        /// Funkcja obsługi kliknięcia na przycisk kontrastu
        /// Modyfikuje kontrast zgodnie ze wskazaniem suwaka i zeruje suwak.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonKontrast_Click(object sender, EventArgs e)
        {
            double Contrast = (100 + (double)this.kontrastScroll.Value) / 100;
            Contrast *= Contrast;

            if (this.ParentForm.ActiveMdiChild != null)
            {
                float Mnoznik = (float)(Bitmap.GetPixelFormatSize(bmp.PixelFormat)) / 8;
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    int nVal;
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - (int)(bmp.Width * Mnoznik);
                    int nWidth = (int)(bmp.Width * Mnoznik);
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            nVal = (int)((((((double)(p[0]) / 255) - 0.5) * Contrast) + 0.5) * 255);
                            if (nVal < 0) nVal = 0;
                            if (nVal > 255) nVal = 255;
                            p[0] = (byte)nVal;
                            ++p;
                        }
                        p += nOffset;
                    }
                }
                bmp.UnlockBits(bmData);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
            }
            this.kontrastScroll.Value = 0;
            this.textBox2.Text = "0";
        }

        /// <summary>
        /// Funkcja obsługi kliknięcia na przycisk jasności
        /// Modyfikuje kontrast zgodnie ze wskazaniem suwaka i zeruje suwak.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJasnosc_Click(object sender, EventArgs e)
        {
            int nBrightness = this.jasnoscScroll.Value;
            if (this.ParentForm.ActiveMdiChild != null)
            {
                float Mnoznik = (float)(Bitmap.GetPixelFormatSize(bmp.PixelFormat)) / 8;
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    int nVal;
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - (int)(bmp.Width * Mnoznik);
                    int nWidth = (int)(bmp.Width * Mnoznik);
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            nVal = (int)(p[0] + nBrightness);
                            if (nVal < 0) nVal = 0;
                            if (nVal > 255) nVal = 255;
                            p[0] = (byte)nVal;
                            ++p;
                        }
                        p += nOffset;
                    }
                }
                bmp.UnlockBits(bmData);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(bmp);
            }
            this.jasnoscScroll.Value = 0;
            this.textBox1.Text = "0";
        }
    
    
    
    
    }
}
