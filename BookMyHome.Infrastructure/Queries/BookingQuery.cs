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

        BookingDto IBookingQuery.GetBooking(int accommodationId, int bookingId)
        {
            var accommodation = _db.Accommodations.Include(a => a.Bookings).AsNoTracking()
                .Single(a => a.Id == accommodationId);

            var booking = accommodation.Bookings.Single(b => b.Id == bookingId);

            return new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                AccommodationId = accommodation.Id,
                RowVersion = booking.RowVersion
            };
        }

        IEnumerable<BookingDto> IBookingQuery.GetBookings(int accommodationId)
        {
            var accommodation = _db.Accommodations.Include(b => b.Bookings).AsNoTracking().Single(a => a.Id == accommodationId);
            var result = accommodation.Bookings.
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
