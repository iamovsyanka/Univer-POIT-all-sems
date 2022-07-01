using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //rss
        {
            proccessRequest("rss");
        }

        private void button2_Click(object sender, EventArgs e) //atom
        {
            proccessRequest("atom");
        }

        private void proccessRequest(string format)
        {
            var req = (HttpWebRequest)WebRequest.Create(@"http://localhost:8000/Lab7/Feed1/students/" + textBox1.Text + "/notes?format=" + format);
            var res = (HttpWebResponse)req.GetResponse();
            string content = new StreamReader(res.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = FormatXml(content);
        }

        private string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }
    }
}
