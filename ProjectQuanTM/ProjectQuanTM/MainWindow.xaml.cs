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
        private readonly RentRepository rentRepository = new RentRepository();

        public MainWindow()
        {
            InitializeComponent();
            LoadRent();
        }
        private void LoadRent()
        {
            var rents = rentRepository.GetRents();
            listRent.ItemsSource = rents;
        }

        private void listRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rent = listRent.SelectedItem as RentViewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listRent.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng trong danh sách");
                return;
            }
            var r = listRent.SelectedItem as RentViewModel;
            var result = rentRepository.DeleteRent(r.RentId);
            LoadRent();
            MessageBox.Show(result);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddRent addRent = new AddRent();
            addRent.Show();
            this.Close();
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomManager roomManager = new RoomManager();
            roomManager.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceManager serviceManager = new ServiceManager();
            serviceManager.Show();
            this.Close();
        }
    }
}