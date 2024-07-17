using DataAccess.Repository.Rent;
using DataAccess.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ProjectQuanTM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadRent();
        }
        private void LoadRent()
        {
            var rent = new RentRepository();
            var rents = rent.GetRents();
            listRent.ItemsSource = rents;
        }

        private void listRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rent = listRent.SelectedItem as RentViewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var r = listRent.SelectedItem as RentViewModel;
            var rent = new RentRepository();
            rent.DeleteRent(r.RentId);
            LoadRent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddRent addRent = new AddRent();
            addRent.Show();
            this.Close();
        }
    }
}