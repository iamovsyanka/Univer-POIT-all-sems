using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private string text;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLength_Click(object sender, EventArgs e)
        {
            try
            {
                inform.Text = $"Количество символов: {text.Length}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGl_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[а|о|у|е|я|ё|ю|э|ы|и|y|a|u|o|i]");
                MatchCollection matches = regex.Matches(text);
                inform.Text = $"Количество гласных: {matches.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSgl_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[q|w|r|t|p|s|d|f|g|h|j|k|l|z|x|c|v|b|n|m|й|ц|к|н|г|ш|щ|з|х|ъ|ф|в|п|р|л|д|ж|э|ч|с|м|т|ь|б]");
                MatchCollection matches = regex.Matches(text);
                inform.Text = $"Количество гласных: {matches.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            text = null;
            textBox1.Text = null;
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[A-z|А-я]+");
                MatchCollection matches = regex.Matches(text);
                inform.Text = $"Количество слов: {matches.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSentence_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[.|!|?]");
                MatchCollection matches = regex.Matches(text);
                inform.Text = $"Количество предложений: {matches.Count}";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => text = textBox1.Text;

        private void inform_Click(object sender, EventArgs e){  }

        private void DeleteButtonBack_Click(object sender, EventArgs e) => SearchSubStr2.Text = null;

        private void ChangeOkButton_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            try
            {
                textBox1.Text = str.Replace(SearchSubStr.Text, ChangeSubStr.Text);
            }
            catch
            {
                MessageBox.Show("Неверно заданы аргументы замены");
            }
            SearchSubStr.Text = null;
            ChangeSubStr.Text = null;
            ChangingBackButton_Click(sender, e);
        }

        private void ChangingBackButton_Click(object sender, EventArgs e) => SearchSubStr.Text = null;    

        private void DeleteOkButton_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            try
            {
                textBox1.Text = str.Replace(SearchSubStr2.Text, "");
            }
            catch
            {
                MessageBox.Show("Неверно задана строка для удаления");
            }
            SearchSubStr2.Text = null;
            DeleteButtonBack_Click(sender, e);
        }

        private void IndexValue_TextChanged(object sender, EventArgs e)
        {
            int index;
            try
            {
                if (int.TryParse(IndexValue.Text, out index))
                {
                   label1.Text = textBox1.Text[index - 1].ToString();
                }
                else
                {
                    label1.Text = null;
                }
            }
            catch
            {
                MessageBox.Show("Неверный индекс");
                label1.Text = null;
            }
        }
    }
}
