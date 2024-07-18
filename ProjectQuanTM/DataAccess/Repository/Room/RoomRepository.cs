using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repository.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly QuanLyTroQuanContext context = new QuanLyTroQuanContext();

        public void AddRoom(RoomCreateRequestViewModel room)
        {
            var roomId = 1;
            try
            {
                roomId = context.Rooms.Max(r => r.Id) + 1;
            }
            catch
            {
                roomId = 1;
            }

            var newRoom = new Models.Room
            {
                Id = roomId,
                Name = room.RoomName,
                Price = room.Price,
                Status = true,
                IsEmpty = true
            };
            context.Rooms.Add(newRoom);
            context.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = context.Rooms.Find(roomId);
            room.Status = false;
            context.SaveChanges();
        }

        public IEnumerable<RoomViewModel> GetRooms()
        {
            var rooms = context.Rooms.Select(r => new RoomViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Price = r.Price,
                Status = r.Status ? "Còn kinh doanh" : "Ngừng kinh doanh",
                IsEmpty = r.IsEmpty == true ? "Chưa thuê" : "Đã thuê"
            }).ToList();
            return rooms;
        }

        public IEnumerable<RoomViewModel> GetRoomsForService()
        {
            var rooms = from r in context.Rents
                        join room in context.Rooms on r.RoomId equals room.Id
                        where room.IsEmpty == false
                        select new RoomViewModel
                        {
                            Id = room.Id,
                            Name = room.Name
                        };
            return rooms;

        }

        public void UpdateRoom(Models.Room room)
        {
            var r = context.Rooms.Find(room.Id);
            r.Name = room.Name;
            r.Price = room.Price;
            context.SaveChanges();
        }
    }
}
