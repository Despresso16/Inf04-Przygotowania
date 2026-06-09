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

namespace Inf04Tydzien2Zad10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listRdBtn.IsChecked = true;
        }

        private void listRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(listRdBtn.IsChecked == true)
            {
                obrazekImg.Source = new BitmapImage(new Uri("/images/list.png", UriKind.Relative));
                cenaTxtBlock.Text = "Cena: 4,99 zł";
                opisTxtBlock.Text = "Czas dostawy 21-37 dni roboczych";
            }

        }

        private void paczkaRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(paczkaRdBtn.IsChecked == true)
            {
                obrazekImg.Source = new BitmapImage(new Uri("/images/paczka.png", UriKind.Relative));
                cenaTxtBlock.Text = "Cena: 14,99 zł";
                opisTxtBlock.Text = "Czas dostawy 1-3 dni robocze";
            }
        }

        private void kurierRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(kurierRdBtn.IsChecked == true)
            {
                obrazekImg.Source = new BitmapImage(new Uri("/images/kurier.png", UriKind.Relative));
                cenaTxtBlock.Text = "Cena: 24,99 zł";
                opisTxtBlock.Text = "Czas dostawy do 67 minut";
            }
        }
    }
}