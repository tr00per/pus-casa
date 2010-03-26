using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace klient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                PUS.Service serwis = new klient.PUS.Service(); //utworzenie obiektu reprezentującego
                //// zdalną usługę
                textBox3.AppendText("\r\n=============\r\n");
                textBox3.AppendText(new string(serwis.getFile(textBox1.Text))); // Wywołujemy zdalną metodę 
                textBox3.AppendText("\r\n=============\r\n");
            }
            catch (Exception ex)				        
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
