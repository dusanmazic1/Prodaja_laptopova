using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Prodaja_laptopova
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        int indeksLP;
        static OpenFileDialog openFile = new OpenFileDialog();
        static BitmapImage bitmapImg = new BitmapImage();


        public AddWindow(int i)
        {
            InitializeComponent();
            cmbModel.ItemsSource = Modeli.modeli;
            openFile.FileName = "SlikaLapTopa";
            if (i==-1)
            {
                indeksLP = -1;
            }
            else
            {
                indeksLP = i;
                btnAdd.Content = "Izmeni";
                dodajLap.Content = "IZMENI LAPTOP";

                imgSlika.Source = new BitmapImage(new Uri(MainWindow.Laptopovi[indeksLP].img));
                cmbModel.SelectedValue = MainWindow.Laptopovi[indeksLP].model;                
                txtNaziv.Text = MainWindow.Laptopovi[indeksLP].naziv;                
                txtGar.Text = MainWindow.Laptopovi[indeksLP].garancija.ToString();
                dataVreme.SelectedDate = MainWindow.Laptopovi[indeksLP].vreme;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Laptop novi;
            if (validacija())
            {
                if(indeksLP == -1)//ako ne postoji clan u listi Laptopovi dodajem novog
                {
                    
                      DateTime date = dataVreme.SelectedDate.Value;
                      novi= new Laptop(txtNaziv.Text, cmbModel.SelectedValue.ToString(), Convert.ToInt32(txtGar.Text), date, imgSlika.Source.ToString());
                      MainWindow.Laptopovi.Add(novi);
                      this.Close();
                }
                else//ako postoji menjam ga
                {
                    DateTime date = dataVreme.SelectedDate.Value;
                    novi = new Laptop(txtNaziv.Text, cmbModel.SelectedValue.ToString(), Convert.ToInt32(txtGar.Text), date, imgSlika.Source.ToString());
                    MainWindow.Laptopovi[indeksLP] = novi ;
                    this.Close(); ;
                }
            }
            else
            {
                MessageBox.Show("Podaci nisu dobro popunjeni.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool validacija()
        {
            bool result = true;

            if (txtNaziv.Text.Trim().Equals(""))
            {
                result = false;
                erorNaziv.Content = "Prazno!";
                txtNaziv.BorderBrush = Brushes.Red;
            }
            else
            {
                erorNaziv.Content = "";
                txtNaziv.BorderBrush = Brushes.Gray;
            }

            if (cmbModel.SelectedItem == null)
            {
                result = false;
                erorModel.Content = "Prazno!";
                cmbModel.BorderBrush = Brushes.Red;
            }
            else
            {
                erorModel.Content = "";
                cmbModel.BorderBrush = Brushes.Gray;
            }

            if (txtGar.Text.Trim().Equals(""))
            {
                result = false;
                erorGaran.Content = "Prazno!";
                txtGar.BorderBrush = Brushes.Red;

            }
            else
            {
                if (!Int32.TryParse(txtGar.Text.Trim(), out int n))
                {
                    result = false;
                    erorGaran.Content = "Nije broj!";
                    txtGar.BorderBrush = Brushes.Red;
                }
                else if (n < 0)
                {
                    result = false;
                    erorGaran.Content = "Nije dobar broj!";
                    txtGar.BorderBrush = Brushes.Red;
                }
                else
                {
                    erorGaran.Content = "";
                    txtGar.BorderBrush = Brushes.Gray;
                }
            }

            if (dataVreme.SelectedDate == null)
            {
                result = false;
                erorVreme.Content = "Prazno!";
                dataVreme.BorderBrush = Brushes.Red;
            }
            else
            {
                erorVreme.Content = "";
                dataVreme.BorderBrush = Brushes.Gray;
            }

            if (openFile.FileName == "SlikaLapTopa" && indeksLP == -1)
            {
                result = false;
                erorSlika.Content = "Prazno!";
                erorSlika.BorderBrush = Brushes.Red;
            }
            else
            {
                erorSlika.Content = "";
                erorSlika.BorderBrush = Brushes.White;
            }

            return result;
        }

        private void btnSlika_Click(object sender, RoutedEventArgs e)
        {
            openFile.FileName = "SlikaLapTopa";
            openFile.Title = "Select a picture";
            openFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (openFile.ShowDialog() == true)
            {
                imgSlika.Source = new BitmapImage(new Uri(openFile.FileName));
                bitmapImg = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
