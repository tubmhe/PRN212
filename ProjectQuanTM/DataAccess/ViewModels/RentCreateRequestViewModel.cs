namespace DataAccess.ViewModels
{
    public class RentCreateRequestViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
        public double Deposits { get; set; }
    }
}
