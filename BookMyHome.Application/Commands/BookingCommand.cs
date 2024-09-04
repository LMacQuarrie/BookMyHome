﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Commands
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingDomainService _domainService;
        private readonly IBookingRepository _repository;
        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
        {
            _domainService = domainService;
            _repository = repository;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            // Do
            var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, _domainService);
            // Save
            _repository.AddBooking(booking);
        }

        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load
            // Do
            // Save
        }

        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            // Load
            var booking = _repository.GetBooking(updateBookingDto.Id);

            // Do
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

            // Save
            _repository.UpdateBooking(booking);
        }
    }
}
