using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PUS2
{
    public partial class Main : Window
    {
        TcpClient client;
        TcpListener server;
        System.Text.Encoding encoding;

        const Int32 queryPort = 4000;
        const int bufferSize = 512;

        public void Log(String msg)
        {
            Output.AppendText(msg + "\r\n");
        }

        public Main()
        {
            InitializeComponent();
        }

        private void InitializeNetwork(object sender, RoutedEventArgs e)
        {
            Status.Content = "Ready!";
            client = null;
            server = null;
            encoding = new System.Text.ASCIIEncoding();
        }

        private void ServerStart_Click(object sender, RoutedEventArgs e)
        {
            if (server != null)
            {
                return;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }

            server = new TcpListener(IPAddress.Any, queryPort);

            server.Start();

            bool running = true;
            byte[] buffer = new byte[bufferSize];

            while (running)
            {
                if (server.Pending())
                {
                    client = server.AcceptTcpClient();
                    Log("Client accepted: " + client.ToString());

                    NetworkStream stream = client.GetStream();
                    String query = encoding.GetString(buffer);

                    stream.Read(buffer, 0, bufferSize);
                    
                    Log("Got queried: " + query);

                    byte[] response = GatherOutputdata(query);

                    stream.Write(response, 0, response.Length);

                    stream.Close();

                    Log("Client got served.");
                }                
            }

            server.Stop();
            server = null;

            Log("Server stopped.");
        }

        private byte[] GatherOutputdata(string query)
        {
            byte[] ret = {(byte)'A', (byte)'B', (byte)'C'};
            return ret;
        }

        private void SendQuery_Click(object sender, RoutedEventArgs e)
        {
            if (server != null)
            {
                //TODO inform pending clients that fun is over
                server.Stop();
                server = null;
            }

            try
            {
                client = new TcpClient(RemoteHostAddress.Text, queryPort);
            }
            catch (SocketException exep)
            {
                Log("Unable to connect with " + RemoteHostAddress.Text);
                Log("[Exception] " + exep.Message);
                return;
            }

            Log("Connected to server: " + RemoteHostAddress.Text);

            NetworkStream stream = client.GetStream();

            Log("Sending query: " + QueryBox.Text);
            stream.Write(encoding.GetBytes(QueryBox.Text), 0, QueryBox.Text.Length);

            Log("Awaiting response...");
            byte[] buffer = new byte[bufferSize];
            while (stream.DataAvailable)
            {
                stream.Read(buffer, 0, bufferSize);
                Output.AppendText(encoding.GetString(buffer));
            }

            stream.Close();

            client.Close();
            client = null;

            Log("\r\nConnection ended.");
        }
    }
}
