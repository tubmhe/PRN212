namespace DataAccess.Repository.Rent
{
    internal interface IRentRepository
    {
        public void AddRent(ViewModels.RentCreateRequestViewModel rent);

        public IEnumerable<ViewModels.RentViewModel> GetRents();

        public void UpdateRent(Models.Rent rent);

        public string DeleteRent(int id);

        public int GetRentIdFromRoomName(string roomName);

        public int GetRentIdFromRoomId(int roomId);
    }
}
