using DataAccess.Models;
using DataAccess.Repository.Rent;
using DataAccess.ViewModels;
using System.Windows;
namespace ProjectQuanTM
{
    /// <summary>
    /// Interaction logic for AddRent.xaml
    /// </summary>
    public partial class AddRent : Window
    {
        public AddRent()
        {
            InitializeComponent();
            LoadRoomNames();
        }

        private void LoadRoomNames()
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var rooms = context.Rooms.Select(r => r.Id).ToList();
                tbRoomName.ItemsSource = rooms;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var rentDao = new RentRepository();
            var createRent = new RentCreateRequestViewModel
            {
                CustomerId = tbID.Text,
                CustomerName = tbName.Text,
                PhoneNumber = tbPhoneNumber.Text,
                RoomId = int.Parse(tbRoomName.Text),
                Deposits = double.Parse(tbDeposits.Text)
            };

            rentDao.AddRent(createRent);
            MessageBox.Show("Kí hợp đồng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void tbRoomName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
