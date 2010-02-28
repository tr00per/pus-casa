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
            lastJasnosc = 0;
            lastKontrast = 0;
        }

        private void jasnosc_Scroll(object sender, EventArgs e)
        {
            int nBrightness = this.jasnoscScroll.Value - this.lastJasnosc;
            if (this.ParentForm.ActiveMdiChild != null)
            {
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    int nVal;
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - bmp.Width * 3;
                    int nWidth = bmp.Width * 3;
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
            this.lastJasnosc = this.jasnoscScroll.Value;
            this.textBox1.Text = lastJasnosc.ToString();
            
        }

        private void kontrastScroll_MouseCaptureChanged(object sender, EventArgs e)
        {
            int nContrast = (this.kontrastScroll.Value - this.lastKontrast);
            double Contrast = (100 + (double)nContrast) / 100;
            Contrast *= Contrast;
            if (this.ParentForm.ActiveMdiChild != null)
            {
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    int nVal;
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - bmp.Width * 3;
                    int nWidth = bmp.Width * 3;
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
            this.lastKontrast = this.kontrastScroll.Value;
            this.textBox2.Text = lastKontrast.ToString();
        }


        public void getBitmap()
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                bmp = ((Form2)this.ParentForm.ActiveMdiChild).getChanged();
                this.lastJasnosc = 0;
                this.lastKontrast = 0;
                this.jasnoscScroll.Value = 0;
                this.textBox1.Text = "0";
                this.kontrastScroll.Value = 0;
                this.textBox2.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - bmp.Width * 3;
                    int nWidth = bmp.Width * 3;
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




    }
}
