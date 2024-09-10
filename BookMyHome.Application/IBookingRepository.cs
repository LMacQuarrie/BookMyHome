using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking, byte[] rowVersion);
        void DeleteBooking(Booking booking, byte[] rowVersion);
    }
}
