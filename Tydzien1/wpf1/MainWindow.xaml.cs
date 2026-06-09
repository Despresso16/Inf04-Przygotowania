using System.Collections.ObjectModel;
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

namespace Inf04Tydzien1Zad5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Egzaminator> ListaEgzaminatorow;
        public MainWindow()
        {
            ListaEgzaminatorow = new ObservableCollection<Egzaminator>()
            {
                new("John", "Pork", Egzaminator.Specjalizacje.INF02),
                new("Jan", "Nadprędkość", Egzaminator.Specjalizacje.INF03),
                new("Stefan", "Minecraft", Egzaminator.Specjalizacje.INF04),
                new("John", "Roblox", Egzaminator.Specjalizacje.INF03),
                new("Jan", "Egzamin", Egzaminator.Specjalizacje.INF04)
            };
            
            InitializeComponent();
            WyswietlEgzaminatorow();
        }

        private void szukajBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;
            if(int.TryParse(idTxtBox.Text.Trim(), out id))
            {
                if(id >= 0)
                {
                    foreach(Egzaminator egzaminator in ListaEgzaminatorow)
                    {
                        if(egzaminator.getID() == id)
                        {
                            wynikWyszukiwaniaLbl.Foreground = Brushes.DarkGreen;
                            wynikWyszukiwaniaLbl.Content = egzaminator.ToString();
                            return;
                        }
                    }
                    wynikWyszukiwaniaLbl.Foreground = Brushes.Red;
                    wynikWyszukiwaniaLbl.Content = $"Egzaminator o ID:{id} nie istnieje w naszym systemie";
                }
                else
                {
                    wynikWyszukiwaniaLbl.Foreground = Brushes.Orange;
                    wynikWyszukiwaniaLbl.Content = "Błędny format, dozwolone tylko liczby całkowite dodatnie";
                }
            }
            else
            {
                wynikWyszukiwaniaLbl.Foreground = Brushes.Orange;
                wynikWyszukiwaniaLbl.Content = "Błędny format, dozwolone tylko liczby całkowite dodatnie";
            }
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (specjalizacjaCmbBox.SelectedItem is ComboBoxItem item)
            {
                switch(item.Content.ToString())
                {
                    case "INF.02":
                        ListaEgzaminatorow.Add(new(imieTxtBox.Text, nazwiskoTxtBox.Text, Egzaminator.Specjalizacje.INF02));
                        break;
                    case "INF.03":
                        ListaEgzaminatorow.Add(new(imieTxtBox.Text, nazwiskoTxtBox.Text, Egzaminator.Specjalizacje.INF03));
                        break;
                    case "INF.04":
                        ListaEgzaminatorow.Add(new(imieTxtBox.Text, nazwiskoTxtBox.Text, Egzaminator.Specjalizacje.INF04));
                        break;
                    default:
                        return;

                }

            }
            else
            {
                specjalizacjaCmbBox.Focus();
            }
        }

        private void idTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string? tekst = idTxtBox.Text.Trim();
            int id = 0;
            if(int.TryParse(tekst, out id))
            {
                szukajBtn.IsEnabled=true;
            }
            else
            { 
                szukajBtn.IsEnabled=false;
            }
        }
        private void WyswietlEgzaminatorow()
        {

            egzaminatorzyListBox.ItemsSource = ListaEgzaminatorow;
        }
    }
}