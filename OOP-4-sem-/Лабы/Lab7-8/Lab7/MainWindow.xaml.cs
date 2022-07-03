using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Lab7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var sri = Application.GetResourceStream(new Uri("Style/Normal.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            switch (menuItem.Name)
            {
                case "rus":
                    Resources = new ResourceDictionary()
                    {
                        Source = new Uri(String.Format("Language/LanguageRu.xaml"), UriKind.Relative)
                    };
                    break;
                case "en":
                    Resources = new ResourceDictionary()
                    {
                        Source = new Uri(String.Format("Language/Language.xaml"), UriKind.Relative)
                    };
                    break;
            }
        }

        private void AboutClick(object sender, RoutedEventArgs e) => System.Windows.MessageBox.Show("Created by Ovsyanka");

        private void ChangeStyleClick(Object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var uri = new Uri($"Style/{menuItem.Name}.xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var open = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|HTML file (*.html)|*.html|All files (*.*)|*.*"
                };
                if (open.ShowDialog() == true)
                {
                    var fileStream = new FileStream(open.FileName, FileMode.Open);
                    var range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                    range.Load(fileStream, DataFormats.Rtf);
                    fileNameTextBlock.Text = open.FileName;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|HTML file (*.html)|*.html|All files (*.*)|*.*"
                };
                if (save.ShowDialog() == true)
                {
                    var fileStream = new FileStream(save.FileName, FileMode.Create);
                    var range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                    range.Save(fileStream, DataFormats.Rtf);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void NewFileClick(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show("Save the current file?", "Save", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileClick(sender, e);
            }
            textBox.Document.Blocks.Clear();
        }

        private void CloseClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void ColorPicker1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            textBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(ColorPicker.SelectedColor.Value));
            textBox.Focus();
        }

        private void Fonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, Fonts.SelectedValue);
            textBox.Focus();
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox != null)
            {
                textBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(((ComboBoxItem)comboBox.SelectedItem).Content));
            }
            textBox.Focus();
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Bold.IsChecked)
            {
                textBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                textBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Underline.IsChecked)
            {
                textBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                textBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Italic.IsChecked)
            {
                textBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                textBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            CharactersCountTextBlock.Text = range.Text.Length.ToString();
        }
    }
}
