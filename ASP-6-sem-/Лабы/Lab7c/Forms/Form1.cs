using System;
using System.ComponentModel;
using System.Windows.Forms;
using Forms.ServiceReference1;

namespace Forms
{
    public partial class Form1 : Form
    {
        Service1Client client = new Service1Client();

        private void GetRecords()
        {
            BindingList<Contact> bindingList = new BindingList<Contact>(client.GetAll());
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
            client.Add(name.Text, phone.Text);
            GetRecords();
        }

        private void update_Click(object sender, EventArgs e)
        {
            client.Update(new Guid(id.Text), name.Text, phone.Text);
            GetRecords();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            client.Delete(new Guid(id.Text));
            GetRecords();
        }
    }
}
