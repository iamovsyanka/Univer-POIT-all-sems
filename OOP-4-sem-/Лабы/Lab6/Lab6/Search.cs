using Lab5;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab6
{
    public partial class Search : Form
    {
        private ShopList shopList;

        public Search()
        {
            InitializeComponent();
        }

        private void Deserialize()
        {
            var serializer = new XmlSerializer(typeof(ShopList));
            if (!File.Exists("ShopList.xml"))
            {
                throw new ApplicationException("Файл не найден!");
            }
            using (var stream = new FileStream("ShopList.xml", FileMode.Open))
            {
                shopList = serializer.Deserialize(stream) as ShopList;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var regex = new Regex(searchTextBox.Text);

            Deserialize();
            try
            {
                foreach (var product in shopList.Products)
                {
                    if (radioName.Checked)
                    {
                        if (regex.IsMatch(product.Name))
                        {
                            listBox1.Items.Add($"Название товара - {product.Name}, номер {product.Number}");
                        }
                    }
                    if (radioPrice.Checked)
                    {
                        var regexRange = new Regex("[" + regex + "]");
                        if (regexRange.IsMatch(product.Price.ToString()))
                        {
                            listBox1.Items.Add($"Название товара - {product.Name}, цена {product.Price}");
                        }
                    }
                    if (TypeProduct.Text == product.Type)
                    {
                        listBox1.Items.Add($"Название товара - {product.Name}, тип {product.Type}");
                    }
                }
            }
            catch { }
        }

        private void buttonBreak_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TypeProduct.SelectedIndex = -1;
            radioName.Checked = false;
            radioPrice.Checked = false;
        }
    }
}
