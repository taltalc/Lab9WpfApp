using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string>() { "Светлая тема", "Тeмная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectedIndex = 0;
            styleBox.SelectionChanged += ThemeChange;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
           int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleIndex==1)
            {
                 uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void StyleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontStyle = (string)styles.SelectedItem;


            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontStyle);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = (string)sizes.SelectedItem;
            if (textBox != null)
            {

                textBox.FontSize = double.Parse(fontSize);
            }
        }
        private void ToolBar_Click(object sender, RoutedEventArgs eventArgs)
        {
            if (eventArgs.OriginalSource == bold)
            {
                if (textBox.FontWeight == FontWeights.Normal)
                {
                    textBox.FontWeight = FontWeights.Bold;
                    bold.Opacity = 0.5;
                }
                else
                {
                    textBox.FontWeight = FontWeights.Normal;
                    bold.Opacity = 1;
                }
            }
            else if (eventArgs.OriginalSource == italic)
            {
                if (textBox.FontStyle == FontStyles.Normal)
                {
                    textBox.FontStyle = FontStyles.Italic;
                    italic.Opacity = 0.5;
                }
                else
                {
                    textBox.FontStyle = FontStyles.Normal;
                    italic.Opacity = 1;
                }
            }
            else if (eventArgs.OriginalSource == underline)
            {
                if (textBox.TextDecorations == TextDecorations.Baseline)
                {
                    textBox.TextDecorations = TextDecorations.Underline;
                    underline.Opacity = 0.5;
                }
                else
                {
                    textBox.TextDecorations = TextDecorations.Baseline;
                    underline.Opacity = 1;
                }
            }

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs arg)
        {

            if (textBox != null)
            {
                if (arg.OriginalSource == red)
                {
                    textBox.Foreground = Brushes.Red;
                }

                else
                {
                    textBox.Foreground = Brushes.Black;
                }
            }


        }


        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый файл(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый файл(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
