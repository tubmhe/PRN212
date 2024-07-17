using DataAccess.Repository.Rent;
using DataAccess.Repository.Room;
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
            var room = new RoomRepository();
            tbRoom.ItemsSource = room.GetRooms();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var rentDao = new RentRepository();
            var createRent = new RentCreateRequestViewModel
            {
                CustomerId = tbID.Text,
                CustomerName = tbName.Text,
                PhoneNumber = tbPhoneNumber.Text,
                RoomId = int.Parse(tbRoom.SelectedValue.ToString()),
                Deposits = double.Parse(tbDeposits.Text)
            };

            rentDao.AddRent(createRent);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void tbRoomName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
