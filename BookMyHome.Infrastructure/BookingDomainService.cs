using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;

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
            var result = _db.Bookings.ToList().Except(new List<Booking>(new[] { booking }));
            //var result = _db.Bookings.Where(a => a.Id != booking.Id).ToList();
            return result;
        }
    }
}
