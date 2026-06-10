using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inf04Tydzien2Zad12._1
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDialogowe.xaml
    /// </summary>
    public partial class OknoDialogowe : Window
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Typ { get; private set; }
        public OknoDialogowe()
        {
            this.Imie = "";
            this.Nazwisko = "";
            this.Typ = "";
            InitializeComponent();
        }

        private void imieTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(imieTxtBox.Text.Trim().Length > 0 && nazwiskoTxtBox.Text.Trim().Length > 0)
            {
                okBtn.IsEnabled = true;
            }
            else { okBtn.IsEnabled = false; }
        }

        private void nazwiskoTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (imieTxtBox.Text.Trim().Length > 0 && nazwiskoTxtBox.Text.Trim().Length > 0)
            {
                okBtn.IsEnabled = true;
            }
            else { okBtn.IsEnabled = false; }
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if(typCmbBox.SelectedItem is ComboBoxItem typWybor)
            {
                this.Imie = imieTxtBox.Text.Trim();
                this.Nazwisko = nazwiskoTxtBox.Text.Trim();
                this.Typ = typWybor.Content.ToString().Trim();
                DialogResult = true;
                Close();
            }
            else
            {
                typCmbBox.Focus();
            }
        }

        private void anulujBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
