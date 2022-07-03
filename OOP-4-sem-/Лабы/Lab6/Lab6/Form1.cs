using Lab6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab5
{
    public partial class Shop : Form
    {
        private ShopList shopList;
        private List<List<Product>> colectionCash;

        public Shop()
        {
            InitializeComponent();

            shopList = new ShopList();
            colectionCash = new List<List<Product>> { };
            toolStripStatusLabel1.Text = $"Текущая дата: {DateTime.Now.ToShortDateString()}, время: {DateTime.Now.ToLongTimeString()}";
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
                var product = new Product();
                var producer = new Producer();

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

                Count.Text = $"Количество товаров: {shopList.Products.Count}";
            }
            catch (Exception)
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
                foreach (Product product in shopList.Products)
                {
                    Data.Text += $"\nНазвание товара: {product.Name}\n";
                    Data.Text += "_______________";
                }
            }
            catch (Exception) { }
        }

        private void CountProduct_Scroll(object sender, EventArgs e) => label7.Text = $"Количество: {CountProduct.Value.ToString()}";
       
        private void PriceProduct_Scroll(object sender, EventArgs e) => label8.Text = $"Цена: {PriceProduct.Value.ToString()}p";
        
        private void SortData_Click(object sender, EventArgs e)
        {
            foreach (var product in shopList.Products.OrderBy(product => product.DateTime))
            {
                sortBox.Text += $"\nНазвание товара: {product.Name}\n";
            }
            colectionCash.Add(shopList.Products.OrderBy(product => product.Name).ToList());
        }

        private void SortCountry_Click(object sender, EventArgs e)
        {
            foreach (var product in shopList.Products.OrderBy(product => product.Producer.Country))
            {
                sortBox.Text += $"\nНазвание товара: {product.Name}\n";
            }
            colectionCash.Add(shopList.Products.OrderBy(product => product.Name).ToList());
        }

        private void SortName_Click(object sender, EventArgs e)
        {
            foreach (var product in shopList.Products.OrderBy(product => product.Name))
            {
                sortBox.Text += $"\nНазвание товара: {product.Name}\n";
            }
            colectionCash.Add(shopList.Products.OrderBy(product => product.Name).ToList());
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var formatter = new XmlSerializer(typeof(List<List<Product>>));
                using (var fs = new FileStream("Sorts.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, colectionCash);
                }
            }
            catch { }
        }

        private void About_Click(object sender, EventArgs e) => MessageBox.Show($"Version {Application.ProductVersion.ToString()}\nOvsyanka");


        private void Search_Click(object sender, EventArgs e)
        {
            var search = new Search();
            search.ShowDialog();
        }

        private void GuidNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"\D");
            if (regex.IsMatch(GuidNumber.Text))
            {
                errorProvider1.SetError(GuidNumber, $"Неверно задан номер товара");
            }
            else
            {
                errorProvider1.Clear();            
            }
        }
    }
}
