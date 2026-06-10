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

namespace Inf04Tydzien2Zad12._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Pracownik> pracownicy;
        public MainWindow()
        {
            pracownicy = new ObservableCollection<Pracownik>();
            InitializeComponent();
            pracownicyListBox.ItemsSource = pracownicy;
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            OknoDialogowe oknoDialogowe = new OknoDialogowe();

            bool? wynik = oknoDialogowe.ShowDialog();

            if(wynik == true)
            {
                pracownicy.Add(new Pracownik(oknoDialogowe.Imie, oknoDialogowe.Nazwisko, oknoDialogowe.Typ));
            }
        }
    }
}