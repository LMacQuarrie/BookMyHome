using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries
{
    public class BookingQuery : IBookingQuery
    {
        private readonly BookMyHomeContext _db;
        public BookingQuery(BookMyHomeContext db)
        {
            _db = db;
        }

        BookingDto IBookingQuery.GetBooking(int id)
        {
            var booking = _db.Bookings.AsNoTracking().Single(a => a.Id == id);

            return new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                RowVersion = booking.RowVersion
            };
        }

        IEnumerable<BookingDto> IBookingQuery.GetBookings()
        {
            var result = _db.Bookings.AsNoTracking().
                Select(a => new BookingDto
            {
                Id = a.Id,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                RowVersion = a.RowVersion
            });
            return result;
        }
    }
}
