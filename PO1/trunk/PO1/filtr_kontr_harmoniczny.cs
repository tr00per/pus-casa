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
    public partial class filtr_kontr_harmoniczny : UserControl
    {
        public filtr_kontr_harmoniczny()
        {
            InitializeComponent();
        }

        private void Filtruj()
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                // Pomocnicze zmienne żeby co chwila w pętli nie odwoływać się do obiektów z panelu
                int szerok = (int)this.szerokosc.Value;
                int wysok = (int)this.wysokosc.Value;
                int szer = (szerok - 1) / 2;
                int wys = (wysok - 1) / 2;
                double Q = (double)this.rzadFiltru.Value;
                // Granice pixeli w których obliczamy...
                int szer_max = source.Width * 3 - 1 - (3 * szer);
                int wys_max = source.Height - 1 - wys;


                //Lista (będzie to lista kolorów branych pod uwagę w liczeniu. Zerowana w każdym przebiegu 
                List<double> listaLicznik = new List<double>();
                List<double> listaMianownik = new List<double>();


                float Mnoznik = (float)(Bitmap.GetPixelFormatSize(source.PixelFormat)) / 8;


                // GDI+ return format is BGR, NOT RGB.
                this.temporary = source.Clone(new Rectangle(0, 0, source.Width, source.Height), source.PixelFormat);
                System.Drawing.Imaging.BitmapData bmData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, source.PixelFormat);
                System.Drawing.Imaging.BitmapData bmData1 = temporary.LockBits(new Rectangle(0, 0, temporary.Width, temporary.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, temporary.PixelFormat);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                System.IntPtr Scan1 = bmData1.Scan0;

                unsafe
                {
                    int indeks = 0;
                    byte* s = (byte*)(void*)Scan0;
                    byte* t = (byte*)(void*)Scan1;
                    int nOffset = stride - (int)(source.Width * Mnoznik);
                    int nWidth = (int)(source.Width * Mnoznik);
                    for (int y = 0; y < source.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            listaLicznik.Clear();
                            listaMianownik.Clear();
                            if (x >= szer * 3 && x <= szer_max && y >= wys && y <= wys_max)
                            {
                                for (int i = -szer * 3; i <= szer * 3; i += 3)
                                {
                                    for (int j = -wys; j <= wys; j++)
                                    {
                                        indeks = (i) + (j * stride);
                                        listaMianownik.Add((double)Math.Pow(s[indeks], Q));
                                        listaLicznik.Add((double)listaMianownik.Last() * s[indeks]);
                                    }
                                }
                                
                                t[0] = (byte)(listaLicznik.Sum() / listaMianownik.Sum());
                            }
                            ++s;
                            ++t;
                        }
                        s += nOffset;
                        t += nOffset;
                    }
                }

                source.UnlockBits(bmData);
                temporary.UnlockBits(bmData1);
                ((Form2)this.ParentForm.ActiveMdiChild).setChanged(temporary);

            }

        }


        private void zastosujFiltr_Click(object sender, EventArgs e)
        {
            Filtruj();
        }

        public void getBitmap()
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                this.temporary = new Bitmap(((Form2)this.ParentForm.ActiveMdiChild).getChanged());
                this.source = this.temporary.Clone(new Rectangle(0, 0, this.temporary.Width, this.temporary.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }
        }

        private void Rzad_ValueChanged(object sender, EventArgs e)
        {
            if (this.ParentForm.ActiveMdiChild != null)
            {
                if (szerokosc.Value >= source.Width) szerokosc.Value = (source.Width / 2 * 2) - 1;
                if (wysokosc.Value >= source.Height) wysokosc.Value = (source.Height / 2 * 2) - 1;
            }
        }


    }
}
