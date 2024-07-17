namespace DataAccess.ViewModels
{
    public class RentViewModel
    {
        public int RentId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoomName { get; set; }
        public int Price { get; set; }
        public double Deposits { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
