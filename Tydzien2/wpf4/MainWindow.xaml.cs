using System.Collections.ObjectModel;
using System.IO;
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
using System.Globalization;

namespace Inf04Tydzien2Zad13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Gra> gry;
        int wybranyIndeks;
        public MainWindow()
        {
            InitializeComponent();
            wybranyIndeks = -1;
            gry = new ObservableCollection<Gra>();

            WczytajPlik();
            BlokadaPrzyciskow();
            gryListView.ItemsSource = gry;
        }

        private void gryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(gryListView.SelectedIndex > -1)
            {
                wybranyIndeks = gryListView.SelectedIndex;
                Gra gra = (Gra)gryListView.SelectedItem;
                WypiszSzczegoly(gra);
            }
        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(wybranyIndeks > 0)
            {
                wybranyIndeks -= 1;
                gryListView.SelectedIndex = wybranyIndeks;
                BlokadaPrzyciskow();
                WypiszSzczegoly(gry[wybranyIndeks]);
            }
            
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if(wybranyIndeks < gry.Count -1)
            {
                wybranyIndeks += 1;
                gryListView.SelectedIndex = wybranyIndeks;
                BlokadaPrzyciskow();
                if(wybranyIndeks > 0) WypiszSzczegoly(gry[wybranyIndeks]);
            }
        }

        private void BlokadaPrzyciskow()
        {
            if(wybranyIndeks <= 0)
            {
                prevBtn.IsEnabled = false;
            }
            else
            {
                prevBtn.IsEnabled=true;
            }

            if(wybranyIndeks >= gry.Count - 1)
            {
                nextBtn.IsEnabled = false;
            }
            else
            {
                nextBtn.IsEnabled=true;
            }

        }

        private void WczytajPlik()
        {
            string? linia;

            StreamReader odczyt = new StreamReader("gry.txt");
            int indeks = 0;
            while((linia = odczyt.ReadLine()) != null)
            {
                if(indeks == 0)
                {
                    indeks++;
                    continue;
                }
                string[] dane = linia.Split(";");
                if (dane.Length < 6) continue;
                int rok = 0;
                double ocena = 0;
                if (int.TryParse(dane[2].Trim(), out rok))
                {
                    if (double.TryParse(dane[3].Trim(), CultureInfo.InvariantCulture, out ocena))
                    {
                        gry.Add(new Gra(dane[0], dane[1], rok, ocena, dane[4], dane[5]));
                    }
                    else continue;
                }
                else continue;
            }
            
            odczyt.Close();
        }

        private void WypiszSzczegoly(Gra gra)
        {
            if (gra == null) return;
            tytulLbl.Content = gra.tytul;
            gatunekLbl.Content = $"Gatunek: {gra.gatunek}";
            rokLbl.Content = $"Rok: {gra.rokWydania}";
            ocenaLbl.Content = $"Ocena: {gra.ocena:F2} / 10";
            obrazekImg.Visibility = Visibility.Visible;
            if (File.Exists($"Images/{gra.nazwaGrafiki}"))
            {
                obrazekImg.Source = new BitmapImage(new Uri($"Images/{gra.nazwaGrafiki}", UriKind.Relative));
            }
            else obrazekImg.Source = new BitmapImage(new Uri("Images/default.png", UriKind.Relative));
        }
    }
}