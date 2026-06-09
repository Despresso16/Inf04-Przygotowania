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

namespace Inf04Tydzien1Zad6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Produkt> listaProduktow;
        public MainWindow()
        {
            listaProduktow = new ObservableCollection<Produkt>();
            InitializeComponent();
            OdczytPliku();
            WyswietlProdukty();
        }

        private void OdczytPliku()
        {
            MessageBox.Show(Environment.CurrentDirectory);
            MessageBox.Show(File.Exists("produkty.txt").ToString());
            if (!File.Exists("produkty.txt"))
            {
                statusSystemuLbl.Content = "Błąd wczytywania produktów z pliku!";
                statusSystemuLbl.Foreground = Brushes.Red;
                return;
            }
            using StreamReader odczyt = new StreamReader("produkty.txt");

            string? linia;

            while((linia = odczyt.ReadLine()) != null)
            {
                string[] dane = linia.Split(';');
                double cena = 0;
                int ilosc = 0;
                if (!double.TryParse(dane[1].Trim(),CultureInfo.InvariantCulture, out cena))
                {
                    continue;
                }
                if (!int.TryParse(dane[2].Trim(), out ilosc))
                {
                    continue;
                }
                listaProduktow.Add(new(dane[0].Trim(), cena, ilosc, dane[3].Trim()));
            }
            int iloscPoprawnychKodow = 0;
            foreach(Produkt produkt in listaProduktow)
            {
                if (produkt.WalidujKod()) iloscPoprawnychKodow += 1;
            }
            statusSystemuLbl.Content = $"Wczytano {listaProduktow.Count} produktów, {iloscPoprawnychKodow} z poprawnym kodem";
            statusSystemuLbl.Foreground = Brushes.White;
        }
        private void WyswietlProdukty()
        {
            GridView kolumny = new GridView();
            kolumny.Columns.Add(new GridViewColumn
            {
                Header = "Nazwa",
                DisplayMemberBinding = new Binding("nazwa"),
                Width = 100
            });
            kolumny.Columns.Add(new GridViewColumn
            {
                Header = "Cena",
                DisplayMemberBinding = new Binding("cena"),
                Width = 50
            });
            kolumny.Columns.Add(new GridViewColumn
            {
                Header = "Ilość",
                DisplayMemberBinding = new Binding("ilosc"),
                Width = 50
            });
            kolumny.Columns.Add(new GridViewColumn
            {
                Header = "Status Kodu",
                DisplayMemberBinding = new Binding("poprawnoscKodu"),
                Width = 120
            });

            listaProduktowListView.View = kolumny;
            listaProduktowListView.ItemsSource = listaProduktow;

        }

        private void listaProduktowListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Produkt? produkt = listaProduktowListView.SelectedItem as Produkt;

            if (produkt == null)
            {
                return;
            }

            pelnaNazwaTxtBlock.Text = produkt.nazwa;
            if (produkt.WalidujKod())
            {
                statusKoduLbl.Content = "Kod Poprawny";
                statusKoduLbl.Foreground = Brushes.Green;
            }
            else
            {
                statusKoduLbl.Content = "Kod Niepoprawny";
                statusKoduLbl.Foreground = Brushes.Red;
            }
            etykietaLbl.Content = $"Etykieta: {produkt.StworzSkroconaEtykiete()}";
        }
    }
}