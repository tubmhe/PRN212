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
        public RoomManager()
        {
            InitializeComponent();
            loadRooms();
        }

        private void loadRooms()
        {
            var room = new RoomRepository();
            var rooms = room.GetRooms();
            listRooms.ItemsSource = rooms;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var room = new RoomCreateRequestViewModel
            {
                RoomName = tbName.Text,
                Price = int.Parse(tbPrice.Text),
            };
            var roomRepository = new RoomRepository();
            roomRepository.AddRoom(room);
            loadRooms();
        }

        private void tbName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void room_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listRooms.SelectedItem != null)
            {
                var selectedRoom = (DataAccess.Models.Room)listRooms.SelectedItem;
                tbNameUpdate.Text = selectedRoom.Name;
                tbPriceUpdate.Text = selectedRoom.Price.ToString();
                tbId.Text = selectedRoom.Id.ToString();
                tbStatus.Text = selectedRoom.Status ? "Hết" : "Còn";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var roomId = int.Parse(tbId.Text);
            var roomRepository = new RoomRepository();
            roomRepository.DeleteRoom(roomId);
            loadRooms();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var room = new DataAccess.Models.Room
            {
                Id = int.Parse(tbId.Text),
                Name = tbNameUpdate.Text,
                Price = int.Parse(tbPriceUpdate.Text),
                Status = tbStatus.Text == "Hết"
            };
            var roomRepository = new RoomRepository();
            roomRepository.UpdateRoom(room);
            loadRooms();
        }
    }
}
