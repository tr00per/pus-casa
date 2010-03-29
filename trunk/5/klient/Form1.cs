using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using klient.Bing;

namespace klient
{
    public partial class Form1 : Form
    {
        const string AppId = "2D5E3B4EB7F570CE3DBAA6603ADADFF5F309A598";

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BingService service = new BingService();

                SearchRequest request = new SearchRequest();

                // Common request fields (required)
                request.AppId = AppId;
                request.Query = textBox1.Text;
                request.Sources = new SourceType[] { SourceType.Web };

                // Common request fields (optional)
                request.Version = "2.0";
                request.Market = "pl-pl";
                request.Adult = AdultOption.Off;
                request.AdultSpecified = true;
                request.Options = new SearchOption[]
        {
       //     SearchOption.DisableLocationDetection
        };

                // Web-specific request fields (optional)
                request.Web = new WebRequest();
                request.Web.Count = 15;
                request.Web.CountSpecified = true;
                request.Web.Offset = 0;
                request.Web.OffsetSpecified = false;
                request.Web.Options = new WebSearchOption[]
        {
            WebSearchOption.DisableHostCollapsing,
            WebSearchOption.DisableQueryAlterations
        };
                string strona = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head><body>";

                SearchResponse response = service.Search(request);

                strona += "<p align=\"right\">Bing API Version " + response.Version.ToString();
                strona += "<br>" + "Web results for \"" + response.Query.SearchTerms;
                strona += "\"   Displaying " + (response.Web.Offset + 1) + " to " + (response.Web.Offset + response.Web.Results.Length) + " of " + response.Web.Total + " results";
                strona += "<p>";

                // Display the Web results.

                foreach (WebResult result in response.Web.Results)
                {
                    strona += "<a href=\"" + result.Url + "\">" + result.Title + "</a><br>";
                    strona += result.Description + "<br>";
                    strona += result.Url + "<br>";
                    strona += "Last Crawled: ";
                    strona += result.DateTime + "<br><br>";

                }
                strona += "</p></body></html>";
                webBrowser1.DocumentText = strona;



            }
            catch (Exception n)
            {
                MessageBox.Show(n.Message, "blad");
            }

        }
    }
}
