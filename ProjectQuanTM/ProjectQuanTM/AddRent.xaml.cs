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
        private readonly RoomRepository roomRepository = new RoomRepository();
        private readonly RentRepository rentRepository = new RentRepository();

        public AddRent()
        {
            InitializeComponent();
            LoadRoomNames();
        }

        private void LoadRoomNames()
        {
            tbRoom.ItemsSource = roomRepository.GetRooms().Where(r => r.Status == "Còn kinh doanh" && r.IsEmpty == "Chưa thuê");
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (tbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi tạo mới");
                return;
            }
            try
            {
                var createRent = new RentCreateRequestViewModel
                {
                    CustomerId = tbID.Text,
                    CustomerName = tbName.Text,
                    PhoneNumber = tbPhoneNumber.Text,
                    RoomId = int.Parse(tbRoom.SelectedValue.ToString()),
                    Deposits = double.Parse(tbDeposits.Text)
                };

                rentRepository.AddRent(createRent);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tạo mới thất bại. Vui lòng điền dữ liệu hợp lệ");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
