using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    System.Text.Encoding encoding;
    string serverRoot;
    public Service () {
        encoding = new System.Text.ASCIIEncoding();
        serverRoot = "C:\\Users\\Andrzej\\Documents\\Visual Studio 2008\\Projects\\PUS\\root";
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public char[] getFile(string query) {
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
        return encoding.GetChars(encoding.GetBytes(ret));
    }
    
}
