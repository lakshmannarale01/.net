using XYZHotels.Interfaces;
using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _repo;

        public RoomService(IRepository <int ,Room> repository)
        {
            _repo=repository;
        }
        public Room AddNewRoom(Room room)
        {
            return _repo.Add(room); 
        }

        public List<Room> GetAllRooms()
        {
           return _repo.GetAll();
        }

        public List<Room> GetInPriceRange(float min, float max)
        {
          var room =_repo.GetAll().Where(x=>x.price>=min &&  x.price<=max).ToList();
            if(room.Count()>0)
            {
                return room.ToList();
            }
            return null;
        }

        public Room UpdatePrice(RoomPriceDTO room)
        {
            var rooms = _repo.Get(room.RoomNo);
            if(rooms!= null)
            {
                rooms.price = room.price;
                return _repo.Update(rooms);
            }return null;


        }
    }
}
