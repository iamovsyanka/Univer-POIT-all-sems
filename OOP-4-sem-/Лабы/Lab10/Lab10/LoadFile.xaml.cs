using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Lab10
{
    public partial class LoadFile : UserControl
    {
        public static DependencyProperty FileNameProperty;
        public LoadFile() => InitializeComponent();

        static LoadFile() => FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(LoadFile),
                new FrameworkPropertyMetadata("Sourse", new PropertyChangedCallback(OnFileNameChanged)));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        private static void OnFileNameChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var file = (LoadFile)sender;
            var str = (string)e.NewValue;
        }

        private void FBCButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var open = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|HTML file (*.html)|*.html"
                };
                if (open.ShowDialog() == true)
                {
                    var fileStream = new FileStream(open.FileName, FileMode.Open);
                    var range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                    range.Load(fileStream, DataFormats.Rtf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
