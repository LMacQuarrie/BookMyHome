using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto bookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);

    }

    public class DeleteBookingDto
    {
        public int Id { get; set; }
    }

    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

    public class CreateBookingDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
