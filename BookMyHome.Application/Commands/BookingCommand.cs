using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Commands.CommandDto;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Helpers;

namespace BookMyHome.Application.Commands
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingDomainService _domainService;
        private readonly IBookingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService, IUnitOfWork unitOfWork)
        {
            _domainService = domainService;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                // Do
                var booking = Booking.Create(createBookingDto.StartDate, createBookingDto.EndDate, _domainService);
                // Save
                _repository.AddBooking(booking);

                //Commit to db
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                // Load
                var booking = _repository.GetBooking(updateBookingDto.Id);

                // Do
                booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                //Commit to db
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                // Load
                var booking = _repository.GetBooking(deleteBookingDto.Id);

                // (Do &) Save
                _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);

                // Commmit to db
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
