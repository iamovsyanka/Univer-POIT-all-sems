using System;
using System.Windows.Forms;

namespace WindowsFormsAppProxy
{
    public partial class Form1 : Form
    {
        readonly Simplex client;
        public Form1()
        {
            InitializeComponent();
            client = new Simplex();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = client.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = client.Concat(textBox4.Text, double.Parse(textBox5.Text));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            A res = client.Sum(new A() { s = textBox7.Text, k = int.Parse(textBox9.Text), f = float.Parse(textBox11.Text) }, new A() { s = textBox8.Text, k = int.Parse(textBox10.Text), f = float.Parse(textBox12.Text) });
            textBox13.Text = res.s;
            textBox14.Text = res.k.ToString();
            textBox15.Text = res.f.ToString();
        }
    }
}
