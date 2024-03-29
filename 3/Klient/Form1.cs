﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemoteClass;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace Klient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adres = textBox1.Text;
           // adres = "http://" + adres;
            adres = "tcp://" + adres;
            int port = (int)numericUpDown1.Value;
            //HttpClientChannel kanal = null;
            TcpClientChannel kanal = null;
            try
            {

                kanal = new TcpClientChannel();
               // kanal = new HttpClientChannel();
                ChannelServices.RegisterChannel(kanal, false);
                RemoteObject obiekt = (RemoteObject)Activator.GetObject(typeof(RemoteObject), adres + ":" + port.ToString() + "/NazwaUslugiIObiektu");
                textBox3.AppendText("\r\n\r\n==================\r\n"+obiekt.getFile(textBox2.Text)+"\r\n==================");
                ChannelServices.UnregisterChannel(kanal);
                textBox3.AppendText("\r\nPołączenie zostało zakończone\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "blad");
                textBox3.AppendText("Blad polaczenia");
                ChannelServices.UnregisterChannel(kanal);
            }
        }
    }
}
