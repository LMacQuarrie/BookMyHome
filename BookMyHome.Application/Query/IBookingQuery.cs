using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int Id);
        IEnumerable<BookingDto> GetBookings();
    }


    // Dto = Data Transfer Object
    public class BookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        
        public byte[] RowVersion { get; set; }
    }
}
