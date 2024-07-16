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
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var rentDao = new RentRepository();
            var createRent = new RentCreateRequestViewModel
            {
                CustomerId = int.Parse(tbID.Text),
                CustomerName = tbName.Text,
                PhoneNumber = tbPhoneNumber.Text,
                RoomId = int.Parse(tbRoomName.Text),
                Deposits = double.Parse(tbDeposits.Text)
            };

            rentDao.AddRent(createRent);
        }

        private void tbRoomName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
