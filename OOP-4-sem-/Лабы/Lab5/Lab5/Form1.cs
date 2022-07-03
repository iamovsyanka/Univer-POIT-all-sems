using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab5
{
    public partial class Shop : Form
    {
        private ShopList shopList;
        private Product product;
        private Producer producer; 

        public Shop()
        {
            InitializeComponent();

            shopList = new ShopList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var formatter = new XmlSerializer(typeof(ShopList));
                using (var fs = new FileStream("ShopList.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, shopList);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check data");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                product = new Product();
                producer = new Producer();

                product.Name = ProductName.Text;
                product.Number = Convert.ToInt32(GuidNumber.Text);
                product.Type = TypeProduct.Text;
                product.Size = SizeProduct.Text;
                product.Count = CountProduct.Value;
                product.DateTime = dateTimePicker1.Value;
                product.Price = PriceProduct.Value;
                if (radioButton1.Checked) product.Weight = radioButton1.Text;
                if (radioButton2.Checked) product.Weight = radioButton2.Text;
                if (radioButton3.Checked) product.Weight = radioButton3.Text;

                producer.Organization = textBox1.Text;
                producer.Country = textBox2.Text;
                producer.Address = textBox3.Text;
                producer.Phone = Convert.ToInt32(textBox4.Text);

                product.Producer = producer;

                shopList.Products.Add(product);
                MessageBox.Show(product.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Check data");
            }
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ShopList));
                using (var stream = new FileStream("ShopList.xml", FileMode.Open))
                {
                    shopList = serializer.Deserialize(stream) as ShopList;
                }
                foreach (Product student in shopList.Products)
                {
                    Data.Text += $"\nНазвание товара: {student.Name}\n";
                    Data.Text += "_______________";
                }
            }
            catch (Exception) { }
        }
    }
}
