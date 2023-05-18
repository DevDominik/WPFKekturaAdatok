using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> szakaszok;
        public MainWindow()
        {
            InitializeComponent();
            szakaszok = File.ReadAllLines("kektura.txt").Select(obj => new Szakasz(obj)).ToList();
            dgAdatok.ItemsSource = szakaszok;
        }

        private void btnSzakasz_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Szakaszok mennyisége: {szakaszok.Count()}", "Szakasz");
        }

        private void btnListaz_Click(object sender, RoutedEventArgs e)
        {
            if (tbSzam.Text.Trim().Length < 1)
            {
                MessageBox.Show("Nincs szám megadva");
                return;
            }
            try
            {
                double a = double.Parse(tbSzam.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Nem helyes a bevitt szám");
                tbSzam.Focus();
                throw;
            }
            List<Szakasz> temp = szakaszok.Where(x => x.Idotartam <= double.Parse(tbSzam.Text.Trim())).ToList();
            dgAdatok.ItemsSource = temp;
            dgAdatok.Items.Refresh();
            lblListazottMennyiseg.Content = temp.Count();
        }

        private void btnPilisAtlag_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Átlagos időtartam: {szakaszok.Where(x => x.Nev.Contains("Pilis")).ToList().Average(x => x.Idotartam)}", "Pilis Átlag");
        }
        private void btnVissza_Click(object sender, RoutedEventArgs e)
        {
            dgAdatok.ItemsSource = szakaszok;
            dgAdatok.Items.Refresh();
            lblListazottMennyiseg.Content = "n/a";
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            Szakasz leghosszabb = szakaszok[0];
            foreach (Szakasz item in szakaszok)
            {
                if (leghosszabb.Tavolsag < item.Tavolsag)
                {
                    leghosszabb = item;
                }
            }
            MessageBox.Show($"{leghosszabb.Nev} - {leghosszabb.Tavolsag} km - {leghosszabb.Idotartam} perc", "Max");
        }
    }
}
