using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Query.QueryDto;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int accommodationId, int bookingId);
        IEnumerable<BookingDto> GetBookings(int accommodationId);
    }
}
