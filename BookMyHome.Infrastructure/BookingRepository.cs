using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookMyHomeContext _db;
        public BookingRepository(BookMyHomeContext context)
        {
            _db = context;
        }
        void IBookingRepository.AddBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        void IBookingRepository.UpdateBooking(Booking booking)
        {
            _db.SaveChanges();
        }

        Booking IBookingRepository.GetBooking(int id)
        {
            return _db.Bookings.Single(booking => booking.Id == id);
        }
    }
}
