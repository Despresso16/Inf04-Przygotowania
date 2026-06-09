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
        double cena;
        string usluga;
        string opis;
        public MainWindow()
        {
            cena = 4.99;
            usluga = "List";
            opis = "Czas dostawy 21-37 dni";
            InitializeComponent();
            listRdBtn.IsChecked = true;
        }

        private void listRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(listRdBtn.IsChecked == true)
            {
                usluga = "List";
                opis = "Czas dostawy 21-37 dni";
            }
            AktualizujWyglad();

        }

        private void paczkaRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (paczkaRdBtn.IsChecked == true)
            {
                usluga = "Paczka";
                opis = "Czas dostawy 67-69 dni";
            }
            AktualizujWyglad();
        }

        private void kurierRdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (kurierRdBtn.IsChecked == true)
            {
                usluga = "Kurier ekspresowy";
                opis = "Czas dostawy 6-7 dni";
            }
            AktualizujWyglad();
        }


        private void zamowBtn_Click(object sender, RoutedEventArgs e)
        { 
            StringBuilder opcje = new StringBuilder();
            if (ubezpieczenieCk.IsChecked == true) opcje.Append("Ubezpiecznie");
            if (ubezpieczenieCk.IsChecked == true && potwierdzenieCk.IsChecked == true) opcje.Append(", ");
            if (potwierdzenieCk.IsChecked == true) opcje.Append("Potwierdzenie odbioru");
            MessageBox.Show($"Potwierdzenie zamówienia\n" +
                $"---\n" +
                $"Przesylka: {usluga}\n" +
                $"Opcje: {opcje.ToString()}\n" +
                $"Łacznie: {cena:F2} zł", "Potwierdzenie zamówienia");
        }

        private void restBtn_Click(object sender, RoutedEventArgs e)
        {
            opis = "Czas dostawy 21-37 dni";
            usluga = "List";
            listRdBtn.IsChecked = true;
            paczkaRdBtn.IsChecked = false;
            kurierRdBtn.IsChecked = false;
            ubezpieczenieCk.IsChecked = false;
            potwierdzenieCk.IsChecked = false;
            AktualizujWyglad();
        }

        private void AktualizujWyglad()
        {
            cena = WyznaczCene();
            cenaTxtBlock.Text = $"Cena: {cena:F2} zł";
            opisTxtBlock.Text = opis;
            switch (usluga.Trim()) 
            {
                case "List":
                    obrazekImg.Source = new BitmapImage(new Uri("/images/list.png", UriKind.Relative));
                    break;
                case "Paczka":
                    obrazekImg.Source = new BitmapImage(new Uri("/images/paczka.png", UriKind.Relative));
                    break;
                case "Kurier ekspresowy":
                    obrazekImg.Source = new BitmapImage(new Uri("/images/kurier.png", UriKind.Relative));
                    break;
            }

        }
        private double WyznaczCene()
        {
            double wyznaczonaCena = 0;
            if (listRdBtn.IsChecked == true) wyznaczonaCena += 4.99;
            else if (paczkaRdBtn.IsChecked == true) wyznaczonaCena += 14.99;
            else if (kurierRdBtn.IsChecked == true) wyznaczonaCena += 24.99;

            if (ubezpieczenieCk.IsChecked == true)
            {
                wyznaczonaCena += 3;
            }
            if (potwierdzenieCk.IsChecked == true)
            {
                wyznaczonaCena += 1.5;
            }
            return wyznaczonaCena;
        }

        private void ubezpieczenieCk_Click(object sender, RoutedEventArgs e)
        {
            AktualizujWyglad();
        }

        private void potwierdzenieCk_Click(object sender, RoutedEventArgs e)
        {
            AktualizujWyglad();
        }
    }
}