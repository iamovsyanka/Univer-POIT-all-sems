using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Lab1a_client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri target = new Uri("https://localhost:44394/sum");
            WebRequest request = WebRequest.Create(target);
            string postData = "X=" + textBox1.Text + "&Y=" + textBox2.Text;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rdr = new StreamReader(response.GetResponseStream());
            textBox3.Text = rdr.ReadToEnd();
        }
    }
}
