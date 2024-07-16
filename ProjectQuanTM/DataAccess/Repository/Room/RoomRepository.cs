using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repository.Room
{
    public class RoomRepository : IRoomRepository
    {
        public void AddRoom(RoomCreateRequestViewModel room)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var roomId = context.Rooms.Max(r => r.Id);
                if (roomId == null)
                {
                    roomId = 1;
                }
                else
                {
                    roomId++;
                }
                var newRoom = new Models.Room
                {
                    Id = roomId,
                    Name = room.RoomName,
                    Price = room.Price,
                    Status = false
                };
                context.Rooms.Add(newRoom);
                context.SaveChanges();
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var room = context.Rooms.Find(roomId);
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }

        public IEnumerable<Models.Room> GetRooms()
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var rooms = context.Rooms.ToList();
                return rooms;
            }
        }

        public void UpdateRoom(Models.Room room)
        {
            using (var context = new QuanLyTroQuanContext())
            {
                var r = context.Rooms.Find(room.Id);
                r.Name = room.Name;
                r.Price = room.Price;
                r.Status = room.Status;
                context.SaveChanges();
            }
        }
    }
}
