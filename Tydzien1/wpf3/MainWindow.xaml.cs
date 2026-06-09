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

namespace Inf04Tydzien1Zad7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Zamowienie Zamowienie { get; set;  }
        public MainWindow()
        {
            Zamowienie = new Zamowienie();
            Zamowienie.DodajPozycje(new Pozycja("Jabłko", 3.11, 4));
            Zamowienie.DodajPozycje(new Pozycja("Notatka", 1.44, 1));
            InitializeComponent();
            podsumowanieTxtBlock.Text = Zamowienie.Podsumowanie();
        }

        private void obliczBtn_Click(object sender, RoutedEventArgs e)
        {
            double cenaDostawy = 0;
            if(listRdBtn.IsChecked == true)
            {
                cenaDostawy += 5.0;
            }
            else if(paczkaRdBtn.IsChecked == true)
            {
                cenaDostawy += 15.0;
            }

            if (ubezpieczenieCK.IsChecked == true) cenaDostawy += 3;
            if (priorytetCK.IsChecked == true) cenaDostawy += 10;

            double cenaZamowienia = Zamowienie.ObliczSume();
            double pelnaCena = cenaDostawy + cenaZamowienia;
            if (pelnaCena < 50) etykietaLbl.Foreground = Brushes.Green;
            else if (pelnaCena > 50 && pelnaCena < 100) etykietaLbl.Foreground = Brushes.Orange;
            else etykietaLbl.Background = Brushes.Red;
            etykietaLbl.Content = $"Suma zamówienia: {cenaZamowienia:F2} zł + Dostawa {cenaDostawy:F2} zł = Łącznie {pelnaCena:F2} zł";
        }

        private void listRdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listRdBtn.IsChecked == true || paczkaRdBtn.IsChecked == true) obliczBtn.IsEnabled = true;
        }

        private void paczkaRdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listRdBtn.IsChecked == true || paczkaRdBtn.IsChecked == true) obliczBtn.IsEnabled = true;
        }
    }
}