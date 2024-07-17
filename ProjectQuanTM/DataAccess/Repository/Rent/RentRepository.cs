using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repository.Rent
{
    public class RentRepository : IRentRepository
    {

        public IEnumerable<RentViewModel> GetRents()
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var rents = (from r in context.Rents
                             join c in context.Customers on r.CustomerId equals c.Id
                             join ro in context.Rooms on r.RoomId equals ro.Id
                             select new RentViewModel
                             {
                                 CustomerName = c.Name,
                                 PhoneNumber = c.PhoneNumber,
                                 RoomName = ro.Name,
                                 Price = ro.Price,
                                 Deposits = r.Deposits,
                                 StartDate = r.StartDate,
                                 EndDate = r.EndDate
                             }).ToList();
                return rents;
            }
        }

        public void AddRent(RentCreateRequestViewModel rent)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var newCustomer = new Customer
                {
                    Id = rent.CustomerId,
                    Name = rent.CustomerName,
                    PhoneNumber = rent.PhoneNumber
                };
                context.Customers.Add(newCustomer);
                context.SaveChanges();

                var rentId = context.Rents.Select(r => r.Id).Max();

                if (rentId == null)
                {
                    rentId = 1;
                }
                else
                {
                    rentId++;
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
                context.SaveChanges();
            }
        }

        public void UpdateRent(Models.Rent rent)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var rentToUpdate = context.Rents.Find(rent.Id);
                rentToUpdate = rent;
                context.SaveChanges();
            }
        }

        public void DeleteRent(int id)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var rent = context.Rents.Find(id);
                context.Rents.Remove(rent);
                context.SaveChanges();
            }
        }
    }
}
