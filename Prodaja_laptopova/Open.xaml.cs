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

namespace Prodaja_laptopova
{
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class Open : Window
    {
        
        public int j;
        public Open(int i)
        {
            InitializeComponent();
            if(i==-1)
            {
                j = -1;               
                lblNaslov.Visibility = Visibility.Hidden;
                lblModel.Visibility = Visibility.Hidden;
                lblGarancija.Visibility = Visibility.Hidden;
                lblVreme.Visibility = Visibility.Hidden;
                btnOpenClose.Visibility = Visibility.Hidden;
            }
            else
            {
                j = i;
                if (MainWindow.Laptopovi[j].img != "")
                {
                    imgSlika.Source = new BitmapImage(new Uri(MainWindow.Laptopovi[j].img));
                }
                lblNaslov.Content = MainWindow.Laptopovi[j].naziv;
                lblModel.Content = MainWindow.Laptopovi[j].model;
                lblGarancija.Content = MainWindow.Laptopovi[j].garancija;
                lblVreme.Content = MainWindow.Laptopovi[j].vreme;
            }
            
        }


        private void btnOpenClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
