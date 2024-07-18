using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repository.Rent
{
    public class RentRepository : IRentRepository
    {
        private readonly QuanLyTroQuanContext context = new QuanLyTroQuanContext();
        public IEnumerable<RentViewModel> GetRents()
        {
            var rents = (from r in context.Rents
                         join c in context.Customers on r.CustomerId equals c.Id
                         join ro in context.Rooms on r.RoomId equals ro.Id
                         select new RentViewModel
                         {
                             RentId = r.Id,
                             CustomerName = c.Name,
                             PhoneNumber = c.PhoneNumber,
                             RoomName = ro.Name,
                             Price = ro.Price,
                             Deposits = r.Deposits,
                             StartDate = r.StartDate.ToString(),
                             EndDate = r.EndDate == null ? "Đang thuê" : r.EndDate.ToString()
                         }).ToList();
            return rents;
        }

        public void AddRent(RentCreateRequestViewModel rent)
        {
            var newCustomer = new Customer
            {
                Id = rent.CustomerId,
                Name = rent.CustomerName,
                PhoneNumber = rent.PhoneNumber
            };
            context.Customers.Add(newCustomer);
            context.SaveChanges();


            var rentId = 1;
            try
            {
                rentId = context.Rents.Select(r => r.Id).Max() + 1;
            }
            catch
            {
                rentId = 1;
            }

            var newRent = new Models.Rent
            {
                Id = rentId,
                CustomerId = rent.CustomerId,
                RoomId = rent.RoomId,
                Deposits = rent.Deposits,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
            };
            context.Rents.Add(newRent);

            var room = context.Rooms.Find(rent.RoomId);
            room.IsEmpty = false;
            context.SaveChanges();
        }

        public void UpdateRent(Models.Rent rent)
        {
            var rentToUpdate = context.Rents.Find(rent.Id);
            rentToUpdate = rent;
            context.SaveChanges();
        }

        public string DeleteRent(int id)
        {
            var rent = context.Rents.Find(id);
            if (rent.EndDate != null)
            {
                return "Hợp đồng đã kết thúc";
            }
            var room = context.Rooms.Find(rent.RoomId);
            room.IsEmpty = true;
            rent.EndDate = DateOnly.FromDateTime(DateTime.Now);
            context.SaveChanges();
            return "Xóa hợp đồng thành công";
        }

        public int GetRentIdFromRoomName(string roomName)
        {
            var rent = from r in context.Rents
                       join room in context.Rooms on r.RoomId equals room.Id
                       where room.Name == roomName && r.EndDate == null
                       select r;
            return rent.FirstOrDefault().Id;
        }

        public int GetRentIdFromRoomId(int roomId)
        {
            var rent = context.Rents.Where(r => r.RoomId == roomId && r.EndDate == null).FirstOrDefault();
            return rent.Id;
        }
    }
}
