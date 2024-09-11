using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly BookMyHomeContext _db;

        public BookingDomainService(BookMyHomeContext db)
        {
            _db = db;
        }
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            var result = _db.Accommodations
                .Where(a => a.Id == booking.Accommodation.Id)
                .Include(a => a.Bookings)
                .SelectMany(a => a.Bookings)
                .Except(new List<Booking>(new[] { booking }).ToList());

            return result;

        }
    }
}
