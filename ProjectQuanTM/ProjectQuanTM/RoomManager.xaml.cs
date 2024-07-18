using DataAccess.Repository.Room;
using DataAccess.ViewModels;
using System.Windows;

namespace ProjectQuanTM
{
    /// <summary>
    /// Interaction logic for RoomManager.xaml
    /// </summary>
    public partial class RoomManager : Window
    {
        private readonly RoomRepository roomRepository = new RoomRepository();
        public RoomManager()
        {
            InitializeComponent();
            loadRooms();
        }

        private void loadRooms()
        {
            var rooms = roomRepository.GetRooms();
            listRooms.ItemsSource = rooms;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = new RoomCreateRequestViewModel
                {
                    RoomName = tbName.Text,
                    Price = int.Parse(tbPrice.Text),
                };
                roomRepository.AddRoom(room);
                loadRooms();
                MessageBox.Show("Tạo mới thành công");
            }
            catch
            {
                MessageBox.Show("Tạo mới thất bại");
            }

        }

        private void room_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listRooms.SelectedItem != null)
            {
                var selectedRoom = (RoomViewModel)listRooms.SelectedItem;
                tbNameUpdate.Text = selectedRoom.Name;
                tbPriceUpdate.Text = selectedRoom.Price.ToString();
                tbId.Text = selectedRoom.Id.ToString();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listRooms.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa");
                return;
            }
            var roomId = int.Parse(tbId.Text);
            roomRepository.DeleteRoom(roomId);
            loadRooms();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = new DataAccess.Models.Room
                {
                    Id = int.Parse(tbId.Text),
                    Name = tbNameUpdate.Text,
                    Price = int.Parse(tbPriceUpdate.Text),
                };
                roomRepository.UpdateRoom(room);
                loadRooms();
                MessageBox.Show("Đã lưu chỉnh sửa");
            }
            catch
            {
                MessageBox.Show("Chỉnh sửa thất bại");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
