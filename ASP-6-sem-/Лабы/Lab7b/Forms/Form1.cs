using Forms.ServiceReference;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        WebServiceSoapClient client = new WebServiceSoapClient();

        private void GetRecords()
        {
            BindingList<Contact> bindingList = new BindingList<Contact>(client.GetDict());
            var source = new BindingSource(bindingList, null);
            contacts.DataSource = source;
        }

        public Form1()
        {
            InitializeComponent();
            GetRecords();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            client.AddDict(name.Text, phone.Text);
            GetRecords();
        }

        private void update_Click(object sender, EventArgs e)
        {
            client.UpdDict(new Guid(id.Text), name.Text, phone.Text);
            GetRecords();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            client.DelDict(new Guid(id.Text));
            GetRecords();
        }
    }
}
