namespace DataAccess.ViewModels
{
    public class RentViewModel
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoomName { get; set; }
        public int Price { get; set; }
        public double Deposits { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
