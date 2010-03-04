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
    public partial class miary_podobienstwa : UserControl
    {
        public miary_podobienstwa()
        {
            InitializeComponent();
        }

        private void getBitmap()
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.original = new Bitmap(this.openFileDialog1.FileName);
                original=original.Clone(new Rectangle(0, 0, original.Width, original.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                
            }
        }

        public void Activate()
        {
            this.Zaszumiony.Enabled = true;
            this.Odszumiony.Enabled = true;
        }


        public void compute()
        {


            if (this.Zaszumiony.Checked)
            {
                this.szum = new Bitmap(((Form2)this.ParentForm.ActiveMdiChild).getOriginal());
                szum = szum.Clone(new Rectangle(0, 0, szum.Width, szum.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }
            if (this.Odszumiony.Checked)
            {
                this.szum = new Bitmap(((Form2)this.ParentForm.ActiveMdiChild).getChanged());
                szum = szum.Clone(new Rectangle(0, 0, szum.Width, szum.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }

                    this.bl_sredniokwadrat.Text="";
                    this.szczyt_sr_kwadrat.Text="";
                    this.syg_do_szum.Text="";
                    this.szyt_syg_do_szum.Text="";
                    this.MaxRoznica.Text="";
            if (this.original != null && this.szum != null && this.ParentForm.ActiveMdiChild != null)
            {
                if ((szum.Size != original.Size) || (szum.PixelFormat != original.PixelFormat))
                {
                    this.bl_sredniokwadrat.Text = "#######Błąd!!########";
                    this.szczyt_sr_kwadrat.Text = "#######Błąd!!########";
                    this.syg_do_szum.Text = "#######Błąd!!########";
                    this.szyt_syg_do_szum.Text = "#######Błąd!!########";
                    this.MaxRoznica.Text = "#######Błąd!!########";
                    return;
                }


                ///



                //Lista (będzie to lista kolorów branych pod uwagę w liczeniu. Zerowana w każdym przebiegu 
                List<int> listaOrg = new List<int>();
                List<int> listaSzu = new List<int>();
                List<double> temp = new List<double>();

                float Mnoznik = (float)(Bitmap.GetPixelFormatSize(this.original.PixelFormat)) / 8;

                // GDI+ return format is BGR, NOT RGB.
                System.Drawing.Imaging.BitmapData bmData = this.original.LockBits(new Rectangle(0, 0, this.original.Width, this.original.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, this.original.PixelFormat);
                System.Drawing.Imaging.BitmapData bmData1 = this.szum.LockBits(new Rectangle(0, 0, this.szum.Width, this.szum.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, this.szum.PixelFormat);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                System.IntPtr Scan1 = bmData1.Scan0;

                unsafe
                {
                    byte* s = (byte*)(void*)Scan0;
                    byte* t = (byte*)(void*)Scan1;
                    int nOffset = stride - (int)(this.original.Width * Mnoznik);
                    int nWidth = (int)(this.original.Width * Mnoznik);
                    for (int y = 0; y < this.original.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            listaOrg.Add(s[0]);
                            listaSzu.Add(t[0]);

                            ++s;
                            ++t;
                        }
                        s += nOffset;
                        t += nOffset;
                    }
                }

                this.original.UnlockBits(bmData);
                this.szum.UnlockBits(bmData1);

                for (int i = 0; i < listaOrg.Count; i++)
                {
                    temp.Add(Math.Pow((double)(listaOrg[i] - listaSzu[i]), 2));
                }

                double tempSum = 0;
                try
                {

                    tempSum = (double)temp.Sum();
                    
                }
                catch (Exception e) {
                    MessageBox.Show(e.ToString());
                    return;
                }
                int count = temp.Count;

                /// Mamy już wartości [f(x,y)- ^f(x, y)]^2
                /// Teraz błąd średniokwadratowy: 
                /// 
                double a = tempSum / temp.Count;
                this.bl_sredniokwadrat.Text = a.ToString("#.#####");

                /// Teraz Szczytowy błąd średniokwadratowy
                /// 
                a=0;
                double b = Math.Pow(listaOrg.Max(), 2);
                listaSzu.Clear();
                for(int i=0; i<count; i++) a+=(double)temp[i]/b;
                a /= count;
                this.szczyt_sr_kwadrat.Text = a.ToString("#.#####");


                ///Szczytowy stosunek sygnału do szumu.
                a = 10 * Math.Log10((count * b) / tempSum);
                this.szyt_syg_do_szum.Text = a.ToString("#.#####");

                b = a = 0;
                
                for (int i = 0; i < count; i++) b += Math.Pow((double)listaOrg[i], 2);
                a = 10 * Math.Log10(b / tempSum);

                this.syg_do_szum.Text = a.ToString("#.#####");
                b = a = 0;
                a=0;

                for(int i=0; i<count; i++){
                    b= (double)Math.Sqrt(temp[i]);
                    if (b > a) a = b;
                }

                this.MaxRoznica.Text = a.ToString("#.#####");

            }
        }

        private void oryginalny_button_Click(object sender, EventArgs e)
        {
            getBitmap();
            compute();
        }

        private void Zaszumiony_CheckedChanged(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).Przepisz();
        }

        private void Odszumiony_CheckedChanged(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).Przepisz();
        }

    }
}
