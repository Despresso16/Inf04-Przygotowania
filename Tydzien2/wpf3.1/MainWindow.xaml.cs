using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inf04Tydzien2Zad12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void czcionkaCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tekstTxtBlock == null) return;
            if(czcionkaCmbBox.SelectedItem is ComboBoxItem czcionkaWybor)
            {
                switch (czcionkaWybor.Content.ToString().Trim()) 
                {
                    case "Verdana":
                        tekstTxtBlock.FontFamily = new FontFamily("Verdana");
                        break;
                    case "Courier New":
                        tekstTxtBlock.FontFamily = new FontFamily("Courier New");
                        break;
                    case "Times New Roman":
                        tekstTxtBlock.FontFamily = new FontFamily("Times New Roman");
                        break;
                    default:
                        tekstTxtBlock.FontFamily = new FontFamily("Arial");
                        break;
                }

            }
        }

        private void stylCk_Checked(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Background = Brushes.Black;
            czionkaLbl.Foreground = Brushes.White;
            wielkoscOpisLbl.Foreground = Brushes.White;
            wielkoscWartoscLbl.Foreground = Brushes.White;
            stylCk.Foreground = Brushes.White;
            pogrubienieCK.Foreground = Brushes.White;
            kursywaCK.Foreground = Brushes.White;
            czcionkaCmbBox.Foreground = Brushes.Black;
            czcionkaCmbBox.Background = Brushes.White;
            tekstTxtBlock.Foreground = Brushes.White;
        }

        private void stylCk_Unchecked(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Background = Brushes.White;
            czionkaLbl.Foreground = Brushes.Black;
            wielkoscOpisLbl.Foreground = Brushes.Black;
            wielkoscWartoscLbl.Foreground = Brushes.Black;
            stylCk.Foreground = Brushes.Black;
            pogrubienieCK.Foreground = Brushes.Black;
            kursywaCK.Foreground = Brushes.Black;
            czcionkaCmbBox.Foreground = Brushes.Black;
            czcionkaCmbBox.Background = Brushes.Gray;
            tekstTxtBlock.Foreground = Brushes.Black;
        }

        private void pogrubienieCK_Unchecked(object sender, RoutedEventArgs e)
        {
            tekstTxtBlock.FontWeight = FontWeights.Normal;
        }

        private void kursywaCK_Unchecked(object sender, RoutedEventArgs e)
        {
            tekstTxtBlock.FontStyle = FontStyles.Normal;
        }

        private void kursywaCK_Checked(object sender, RoutedEventArgs e)
        {
            tekstTxtBlock.FontStyle = FontStyles.Italic;
        }

        private void pogrubienieCK_Checked(object sender, RoutedEventArgs e)
        {
            tekstTxtBlock.FontWeight = FontWeights.Bold;
        }
    }
}