using XYZHotels.ExceptionHandle;
using XYZHotels.Interfaces;
using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _repo;

        public BookingService(IRepository <int , Booking> repository)
        {
            _repo=repository;
        }
        public Booking AddBooking(Booking booking)
        {
            BookingCheckAvalibilityDTO bca= new BookingCheckAvalibilityDTO
            {
                BookingDateTime = booking.BookingDateTime,
                    RoomNo = booking.RoomNo
            };
            if(CheckAvailability(bca) == true) 
            {
                var book = _repo.Add(booking);
                return book;
            }
            throw new RoomNotAvailableExceptions();
        }

        public Booking CancelBooking(int id)
        {
            var mybook = _repo.Get(id);
            if(mybook == null)
            {
                throw new NoEntriesAvailable("Rooms");
            }
            mybook =_repo.Delete(mybook.BookingId);
            return mybook;
        }
   
public bool CheckAvailability(BookingCheckAvalibilityDTO booking)
        {
            try
            {
                var book = _repo.GetAll();
                var checkBooking = book.FirstOrDefault(x=>x.RoomNo== booking.RoomNo && x.BookingDateTime==booking.BookingDateTime);
                return checkBooking == null;
            }
            catch (RoomNotAvailableExceptions e )
            {

                return true;
            }
            catch(NoEntriesAvailable e)
            {
                return true;
            }
        }

        public IList<Booking> GetAll()
        {
          return _repo.GetAll().ToList();
        }
    }
}
