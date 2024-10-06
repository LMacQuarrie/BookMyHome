using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Commands.CommandDto;

namespace BookMyHome.Application.Commands
{
    public interface IAccommodationCommand
    {
        Task CreateAccommodation(CreateAccommodationDto createAccommodationDto);
        void UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto);
        void DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto);

        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);

        void CreateReview(CreateReviewDto createReviewDto);

    }
}
