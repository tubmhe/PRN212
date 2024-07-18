using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repository.Service
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly QuanLyTroQuanContext context = new QuanLyTroQuanContext();

        public void AddService(Models.Service service)
        {
            var serviceId = 1;
            try
            {
                serviceId = context.Services.Max(s => s.Id) + 1;
            }
            catch
            {
                serviceId = 1;
            }
            service.Id = serviceId;
            context.Services.Add(service);
            context.SaveChanges();
        }

        public IEnumerable<ServiceViewModel> GetServices()
        {
            var services = (from s in context.Services
                            join r in context.Rents on s.RentId equals r.Id
                            join c in context.Customers on r.CustomerId equals c.Id
                            join room in context.Rooms on r.RoomId equals room.Id
                            select new ServiceViewModel
                            {
                                Id = s.Id,
                                CustomerName = c.Name,
                                RoomName = room.Name,
                                DateStart = s.StartDate.ToString(),
                                DateEnd = s.EndDate.ToString(),
                                OldNumber = s.OldNumber,
                                NewNumber = s.NewNumber,
                                TotalAmount = s.Price * (s.NewNumber - s.OldNumber),
                                Status = s.Status ? "Đã thanh toán" : "Chưa thanh toán"
                            }).ToList();
            return services;
        }

        public void UpdateService(Models.Service service)
        {
            var s = context.Services.Find(service.Id);
            s.StartDate = service.StartDate;
            s.EndDate = service.EndDate;
            s.OldNumber = service.OldNumber;
            s.NewNumber = service.NewNumber;
            s.Price = service.Price;
            s.Status = service.Status;
            context.SaveChanges();
        }
    }
}
