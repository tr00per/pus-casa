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
        Thread serverThread;

        const Int32 queryPort = 4000;
        const int bufferSize = 512;

        delegate void LogDelegate(String msg);
        LogDelegate log;
        
        public void Log(String msg)
        {
            Output.AppendText(msg + "\r\n");
            Output.ScrollToEnd();
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Initialize(object sender, RoutedEventArgs e)
        {
            Status.Content = "Ready!";
            client = null;
            server = null;
            encoding = new System.Text.ASCIIEncoding();
            log = new LogDelegate(Log);
        }

        private void runServer()
        {
            server = new TcpListener(IPAddress.Any, queryPort);
            server.Start();

            byte[] buffer = new byte[bufferSize];

            while (true)
            {
                if (server.Pending())
                {
                    client = server.AcceptTcpClient();
                    this.Dispatcher.Invoke(log, (object)("Client accepted: " + client.Client.LocalEndPoint.ToString()));

                    NetworkStream stream = client.GetStream();

                    int trans = stream.Read(buffer, 0, bufferSize);
                    String query = encoding.GetString(buffer, 0, trans);

                    this.Dispatcher.Invoke(log, (object)("Got queried: " + query));

                    byte[] response = GatherOutputdata(query);

                    stream.Write(response, 0, response.Length);

                    stream.Close();
                    client.Close();
                    client = null;

                    this.Dispatcher.Invoke(log, (object)("Client got served."));

                    if (query.Equals("~~kill"))
                    {
                        this.Dispatcher.Invoke(log, (object)("Exiting..."));
                        break;
                    }
                }

            }

            server.Stop();
            server = null;

            this.Dispatcher.Invoke(log, (object)("Server stopped."));
        }

        private void ServerStart_Click(object sender, RoutedEventArgs e)
        {
            if (server != null && serverThread.IsAlive)
            {
                return;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }

            Log("Spawning server...");

            serverThread = new Thread(new ThreadStart(runServer));
            serverThread.Start();
        }

        private byte[] GatherOutputdata(string query)
        {
            if (query.Equals("~~kill"))
            {
                return encoding.GetBytes("SHD");
            }

            //FIXME wstawić działanie programu (na podstawie poprzedniej wersji)
            byte[] ret = encoding.GetBytes("ABC");
            return ret;
        }

        private void SendQuery_Click(object sender, RoutedEventArgs e)
        {
            if (server != null)
            {
                //TODO inform pending clients that fun is over
                serverThread.Interrupt();
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
            do
            {
                int trans = stream.Read(buffer, 0, bufferSize);
                Output.AppendText(encoding.GetString(buffer, 0, trans));
            } while (stream.DataAvailable);
            Output.ScrollToEnd();

            stream.Close();

            client.Close();
            client = null;

            Log("\r\nConnection ended.");
        }

        private void Finish(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (serverThread!= null && serverThread.IsAlive)
            {
                serverThread.Interrupt();
            }
        }
    }
}
