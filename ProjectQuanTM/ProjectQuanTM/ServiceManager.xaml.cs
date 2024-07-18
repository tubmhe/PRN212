using DataAccess.Repository.Rent;
using DataAccess.Repository.Room;
using DataAccess.Repository.Service;
using DataAccess.ViewModels;
using System.Windows;

namespace ProjectQuanTM
{
    /// <summary>
    /// Interaction logic for ServiceManager.xaml
    /// </summary>
    public partial class ServiceManager : Window
    {
        private readonly RoomRepository roomRepository = new RoomRepository();
        private readonly ServiceRepository serviceRepository = new ServiceRepository();
        private readonly RentRepository rentRepository = new RentRepository();

        public ServiceManager()
        {
            InitializeComponent();
            LoadService();
        }

        private void LoadService()
        {
            listServices.ItemsSource = serviceRepository.GetServices();
            listRooms.ItemsSource = roomRepository.GetRoomsForService().ToList();
        }

        private void tbPrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var oldNumber = int.Parse(tbOldNumber.Text);
            var newNumber = int.Parse(tbNewNumber.Text);
            if (oldNumber > newNumber)
            {
                MessageBox.Show("Chỉ số cũ không thể lớn hơn chỉ số mới");
                return;
            }
            var price = int.Parse(tbPrice.Text);
            tbTotalAmount.Text = ((newNumber - oldNumber) * price).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listRooms.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi tạo mới");
                return;
            }
            try
            {
                var roomId = int.Parse(listRooms.SelectedValue.ToString());
                var rentId = rentRepository.GetRentIdFromRoomId(roomId);

                var service = new DataAccess.Models.Service
                {
                    EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                    StartDate = DateOnly.FromDateTime((dpStartDate.SelectedDate.Value)),
                    OldNumber = int.Parse(tbOldNumber.Text),
                    NewNumber = int.Parse(tbNewNumber.Text),
                    Price = int.Parse(tbPrice.Text),
                    RentId = rentId,
                    Status = tbStatus.IsChecked ?? false
                };
                serviceRepository.AddService(service);
                LoadService();
                MessageBox.Show("Tạo mới thành công");
            }
            catch
            {
                MessageBox.Show("Tạo mới thất bại. Vui lòng điền dữ liệu hợp lệ");
            }
        }

        private void listServices_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listRooms.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi chọn dịch vụ");
                return;
            }

            var service = listServices.SelectedValue as ServiceViewModel;
            listRooms.DisplayMemberPath = service.RoomName;
            listRooms.IsReadOnly = true;
            tbOldNumber.Text = service.OldNumber.ToString();
            tbNewNumber.Text = service.NewNumber.ToString();
            tbPrice.Text = 0.ToString();
            tbTotalAmount.Text = service.TotalAmount.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listServices.SelectedValue != null)
            {
                try
                {
                    var s = listServices.SelectedValue as ServiceViewModel;
                    var rentId = rentRepository.GetRentIdFromRoomName(s.RoomName);

                    var service = new DataAccess.Models.Service
                    {
                        Id = s.Id,
                        EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                        StartDate = DateOnly.FromDateTime((dpStartDate.SelectedDate.Value)),
                        OldNumber = int.Parse(tbOldNumber.Text),
                        NewNumber = int.Parse(tbNewNumber.Text),
                        Price = int.Parse(tbPrice.Text),
                        RentId = rentId,
                        Status = tbStatus.IsChecked ?? false
                    };
                    serviceRepository.UpdateService(service);
                    LoadService();
                    MessageBox.Show("Chỉnh sửa thành công");
                }
                catch
                {
                    MessageBox.Show("Chỉnh sửa thất bại. Vui lòng điền dữ liệu hợp lệ");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần chỉnh sửa.");
            }
        }

        private void listServices_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listServices.SelectedValue == null)
            {
                return;
            }

            var service = listServices.SelectedValue as ServiceViewModel;
            listRooms.IsReadOnly = true;
            tbOldNumber.Text = service.OldNumber.ToString();
            tbNewNumber.Text = service.NewNumber.ToString();
            tbPrice.Text = (service.TotalAmount / (service.NewNumber - service.OldNumber)).ToString();
            tbTotalAmount.Text = service.TotalAmount.ToString();
            tbStatus.IsChecked = service.Status == "Đã thanh toán";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
