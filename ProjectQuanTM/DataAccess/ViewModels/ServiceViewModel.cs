namespace DataAccess.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int OldNumber { get; set; }
        public int NewNumber { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
