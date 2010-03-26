using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemoteClass;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;


namespace Server
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
                HttpServerChannel kanal = new HttpServerChannel((int)numericUpDown1.Value);
                ChannelServices.RegisterChannel(kanal, false);
                
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "NazwaUslugiIObiektu", WellKnownObjectMode.Singleton);

                listBox1.Items.Add("Serwer został uruchomiony.");
                listBox1.Items.Add("   Port:" + this.numericUpDown1.Value.ToString());
                listBox1.Items.Add("   IP: ");
                IPAddress[] ipList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                foreach (IPAddress ip in ipList.Reverse())
                {
                    listBox1.Items.Add("        " + ip.ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Blad");
            }
        }
    }
}
