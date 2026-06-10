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

namespace Inf04Tydzien2Zad11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Projekt projekt;
        private int indeksZadania;
        public MainWindow()
        {
            projekt = new Projekt();
            indeksZadania = -1;
            InitializeComponent();
            zadaniaListBox.ItemsSource = projekt.zadania;
        }

        private void opisTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(opisTxtBox.Text.Length > 10)
            {
                dodajBtn.IsEnabled = true;
            }
            else dodajBtn.IsEnabled= false;
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if(priorytetCmbBox.SelectedItem is ComboBoxItem priorytetWybor && statusCmbBox.SelectedItem is ComboBoxItem statusWybor && terminDatePicker.SelectedDate.HasValue)
            {
                int priorytet = 3;
                switch (priorytetWybor.Content)
                {
                    case "Bardzo ważne":
                        priorytet = 1;
                        break;
                    case "Ważne":
                        priorytet = 2;
                        break;
                    default:
                        priorytet = 3;
                        break;
                }
                Zadanie zadanie = new Zadanie(opisTxtBox.Text, priorytet, terminDatePicker.SelectedDate.Value, statusWybor.Content.ToString());
                if (projekt.zadania.Contains(zadanie))
                {
                    MessageBox.Show("Istnieje juz takie zadanie, zmien cos aby dodac", "Błąd przy dodaniu zadania", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                projekt.zadania.Add(zadanie);
                opisTxtBox.Text = "";
                priorytetCmbBox.SelectedItem = null;
                statusCmbBox.SelectedIndex = 0;
                terminDatePicker.SelectedDate = null;
                dodajBtn.IsEnabled = false;
                usunBtn.IsEnabled = false;

            }
            else
            {
                MessageBox.Show("Wypelnij wszystkie pola formularza!", "Błąd przy dodaniu zadania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            if(indeksZadania > -1 && indeksZadania < projekt.zadania.Count)
            {
                MessageBoxResult odpowiedz = MessageBox.Show(this, "Czy napewno chcesz usunac to zadnie?", "Lista zadan", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (odpowiedz)
                {
                    case MessageBoxResult.Yes:
                        opisTxtBox.Text = "";
                        priorytetCmbBox.SelectedItem = null;
                        statusCmbBox.SelectedIndex = 0;
                        terminDatePicker.SelectedDate = null;
                        dodajBtn.IsEnabled = false;
                        usunBtn.IsEnabled = false;
                        projekt.zadania.RemoveAt(indeksZadania);
                        break;
                    default:
                        break;
                }


            }
        }

        private void zadaniaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Zadanie zadanie = (Zadanie)zadaniaListBox.SelectedItem;

            if (zadanie != null)
            {
                opisTxtBox.Text = zadanie.opis;
                terminDatePicker.SelectedDate = zadanie.termin;
                priorytetCmbBox.SelectedIndex = zadanie.priorytet - 1;
                switch (zadanie.status)
                {
                    case "W trakcie":
                        statusCmbBox.SelectedIndex = 1;
                        break;
                    case "Zakończone":
                        statusCmbBox.SelectedIndex = 2;
                        break;
                    default:
                        statusCmbBox.SelectedIndex = 0;
                        break;
                }
                dodajBtn.IsEnabled = false;

                usunBtn.IsEnabled = true;
                indeksZadania = projekt.zadania.IndexOf(zadanie);
            }
        }
    }
}