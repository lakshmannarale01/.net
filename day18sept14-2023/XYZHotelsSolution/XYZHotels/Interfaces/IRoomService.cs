using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        List<Room> GetInPriceRange(float min , float max);

        Room AddNewRoom(Room room);

        Room UpdatePrice(RoomPriceDTO room);
    }
}
