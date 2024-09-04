using BookMyHome.Application.Commands.CommandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);

    }
}
