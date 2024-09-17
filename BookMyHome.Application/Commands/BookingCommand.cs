using BookMyHome.Application.Commands.CommandDto;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Helpers;

namespace BookMyHome.Application.Commands;

public class BookingCommand : IBookingCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IBookingDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public BookingCommand(IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository,
        IBookingDomainService domainService, IUnitOfWork unitOfWork)
    {
        _domainService = domainService;
        _bookingRepository = bookingRepository;
        _accommodationRepository = accommodationRepository;
        _unitOfWork = unitOfWork;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            // Load
            var accommodation = _accommodationRepository.GetAccommodation(createBookingDto.AccommodationId);

            // Do
            var booking = Booking.Create(createBookingDto.StartDate, createBookingDto.EndDate, accommodation,
                _domainService);

            // Save
            _bookingRepository.AddBooking(booking);

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
            var booking = _bookingRepository.GetBooking(updateBookingDto.Id);

            // Do
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

            // Save
            _bookingRepository.UpdateBooking(booking, updateBookingDto.RowVersion);

            // Commit to db
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
            var booking = _bookingRepository.GetBooking(deleteBookingDto.Id);

            // (Do &) Save
            _bookingRepository.DeleteBooking(booking, deleteBookingDto.RowVersion);

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