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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using WpfApp1;
using System.ComponentModel;

namespace Prodaja_laptopova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataIO Serializer = new DataIO();
        public static BindingList<Laptop> Laptopovi { get; set; }

        public MainWindow()
        {
            Laptopovi = Serializer.DeSerializeObject<BindingList<Laptop>>("Laptop.xml");
            if (Laptopovi == null) 
            {
                Laptopovi = new BindingList<Laptop>();
            }

            InitializeComponent();
            DataContext = this;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Save(object sender, CancelEventArgs e) //window_closing
        {
            Serializer.SerializeObject<BindingList<Laptop>>(Laptopovi, "Laptop.xml");
        } 

       

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWin = new AddWindow(-1);

            addWin.ShowDialog();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Laptop laptopovi = (Laptop)dataGridLaptopovi.CurrentItem;
            Laptopovi.Remove(laptopovi);
            
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            int ind = dataGridLaptopovi.SelectedIndex;
            Open open = new Open(ind);
            open.ShowDialog();

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int ind = dataGridLaptopovi.SelectedIndex;
            AddWindow change = new AddWindow(ind);
            change.ShowDialog();
        }

       
    }
}
