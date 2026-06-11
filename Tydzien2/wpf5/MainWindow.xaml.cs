using Microsoft.Win32;
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

namespace Inf04Tydzien2Zad14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SprzetKomputerowy> sprzety;
        public MainWindow()
        {
            InitializeComponent();
            sprzety = new ObservableCollection<SprzetKomputerowy> ();
            ZaladujSprzet();
            sprzetListView.ItemsSource = sprzety;
        }

        private void sprzetListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SprzetKomputerowy sprzet = (SprzetKomputerowy)sprzetListView.SelectedItem;
            if(sprzet != null)
            {
                nazwaLbl.Content = sprzet.Nazwa;
                numerLbl.Content = $"Nr.{sprzet.NumerInwentarzowy}";
                typLbl.Content = sprzet.TypFormat;
                rokLbl.Content = $"Rok zakupu: {sprzet.RokZakupu}";
                wartoscLbl.Content = $"Wartość: {sprzet.CenaPoAmortyzacjiLiniowej():F2} zł";
                statusLbl.Content = $"Amortyzowany: {sprzet.ZamortyzowanieFormat}";
            }
        }

        private void eksportBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog zapisDialog = new SaveFileDialog
            {
                Filter = "Pliki CSV (*.csv)|*.csv",
                DefaultExt = ".csv",
                FileName = "sprzety.csv"
            };

            if(zapisDialog.ShowDialog() == true)
            {
                using StreamWriter zapis = new StreamWriter(zapisDialog.FileName);
                foreach(SprzetKomputerowy sprzet in sprzety)
                {
                    zapis.WriteLine($"{sprzet.NumerInwentarzowy};{sprzet.Nazwa};{sprzet.TypFormat};{sprzet.RokZakupu};{sprzet.Wartosc:F2};{sprzet.PrzypisanaSala}");
                }
            }
        }

        private void ZaladujSprzet()
        {
            string? linia;

            StreamReader odczyt = new StreamReader("sprzetkomputerowy.csv");
            double lacznyKoszt = 0;
            int liczbaZamortyzowanych = 0;
            while ((linia = odczyt.ReadLine())!= null)
            {
                string[] dane = linia.Split(";");
                if (dane.Length < 6) continue;
                double wartosc = 0;
                if (double.TryParse(dane[4].Trim(), out wartosc))
                {
                    SprzetKomputerowy.RodzajSprzetu typ = SprzetKomputerowy.RodzajSprzetu.Inne;
                    switch (dane[2].Trim().ToLower()) 
                    {
                        case "komputer":
                            typ = SprzetKomputerowy.RodzajSprzetu.Komputer;
                            break;
                        case "monitor":
                            typ = SprzetKomputerowy.RodzajSprzetu.Monitor;
                            break;
                        case "drukarka":
                            typ = SprzetKomputerowy.RodzajSprzetu.Drukarka;
                            break;
                        default:
                            break;
                    }
                    SprzetKomputerowy sprzet = new SprzetKomputerowy(dane[1], typ, int.Parse(dane[3].Trim()), wartosc, dane[5].Trim());
                    lacznyKoszt += sprzet.CenaPoAmortyzacjiLiniowej();
                    if (sprzet.Zamortyzowanie()) liczbaZamortyzowanych += 1;
                    sprzety.Add(sprzet);
                }
                else continue;
            }
            lacznyKosztLbl.Content = $"Łączny koszt: {lacznyKoszt:F2} zł";
            iloscLbl.Content = $"Liczba sprzętu w raporcie: {sprzety.Count}, zamortyzowanych: {liczbaZamortyzowanych} szt.";
            if (sprzety.Count > 0) eksportBtn.IsEnabled = true;
        }
    }
}