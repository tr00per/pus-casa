using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RemoteClass
{
    public class RemoteObject: MarshalByRefObject
    {
        System.Text.Encoding encoding;
        string serverRoot;
        RemoteObject()
        {
            encoding = new System.Text.ASCIIEncoding();
            serverRoot = Directory.GetCurrentDirectory();
        }

        public string getFile(string tekst)
        {
            this.InitializeLifetimeService();
            return encoding.GetString(GatherOutputData(tekst));

        }

        private byte[] GatherOutputData(string query)
        {
            byte[] buf = new byte[1024];
            string ret = "";
            string path = serverRoot + query;


            if (File.Exists(path))
            {
                FileStream fin = File.OpenRead(path);

                int read;
                do
                {
                    read = fin.Read(buf, 0, 1024);
                    ret += encoding.GetString(buf, 0, read);
                } while (read == 1024);
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    path = serverRoot;
                }
                //else if ((query.Equals("\\") || query.Equals("/") || query.Equals("") || query.Equals(".")))
                //{
                //     serverRoot= path;
                //     ret += "\r\nKatalog serwera zmieniony na: " + path + "\r\n";
                //     return encoding.GetBytes(ret);
                //} 
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    ret += dir + "\\\r\n";
                }
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    ret += file + "\r\n";
                }
            }
            return encoding.GetBytes(ret);
        }


    }
}
