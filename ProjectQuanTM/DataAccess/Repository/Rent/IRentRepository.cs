namespace DataAccess.Repository.Rent
{
    internal interface IRentRepository
    {
        public void AddRent(ViewModels.RentCreateRequestViewModel rent);

        public IEnumerable<ViewModels.RentViewModel> GetRents();

        public void UpdateRent(Models.Rent rent);

        public void DeleteRent(int id);
    }
}
