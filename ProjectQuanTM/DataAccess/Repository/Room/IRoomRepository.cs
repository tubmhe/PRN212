using DataAccess.ViewModels;

namespace DataAccess.Repository.Room
{
    public interface IRoomRepository
    {
        public IEnumerable<RoomViewModel> GetRooms();

        public void AddRoom(ViewModels.RoomCreateRequestViewModel room);

        public void UpdateRoom(Models.Room room);

        public void DeleteRoom(int roomId);
    }
}
