using BookMyHome.Application.Commands.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.Query.QueryDto;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Entity.ValueObjects;
using BookMyHome.Domain.Services;

namespace BookMyHome.Application.Commands;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IAccommodationRepository _repository;
    private readonly IHostRepository _hostRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGuestRepository _guestRepository;
    private readonly IAddressService _addressService;

    public AccommodationCommand(IAccommodationRepository repository, IHostRepository hostRepository,
        IUnitOfWork unitOfWork, IGuestRepository guestRepository, IAddressService addressService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _hostRepository = hostRepository;
        _guestRepository = guestRepository;
        _addressService = addressService;
    }

    async Task IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            // Load
            var host = _hostRepository.GetHost(createAccommodationDto.HostId);

            // Do
            var accommodation = Accommodation.Create(createAccommodationDto.Price, host);
            await accommodation.AddAddress(createAccommodationDto.CreateAddressDto.Street, createAccommodationDto.CreateAddressDto.City, createAccommodationDto.CreateAddressDto.HouseNumber, createAccommodationDto.CreateAddressDto.PostalCode, createAccommodationDto.CreateAddressDto.Floor, createAccommodationDto.CreateAddressDto.Door, _addressService);

            // Save
            _repository.AddAccommodation(accommodation);

            // Commit to db
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            // Load
            var accommodation = _repository.GetAccommodation(updateAccommodationDto.Id);

            // Do
            accommodation.Update(updateAccommodationDto.Price);

            // Save
            _repository.UpdateAccommodation(accommodation, updateAccommodationDto.RowVersion);

            //Commit to db
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            // Load
            var accommodation = _repository.GetAccommodation(deleteAccommodationDto.Id);

            // (Do &) Save
            accommodation.Delete();
            _repository.DeleteAccommodation(accommodation, deleteAccommodationDto.RowVersion);

            // Commmit to db
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.CreateBooking(CreateBookingDto createBookingDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            // Load
            Accommodation accommodation = _repository.GetAccommodation(createBookingDto.AccommodationId);
            Guest guest = _guestRepository.GetGuest(createBookingDto.GuestId);

            // Do
            accommodation.CreateBooking(createBookingDto.StartDate, createBookingDto.EndDate, guest);

            // Save
            _repository.AddBooking();

            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _unitOfWork.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }

            throw;
        }
    }

    void IAccommodationCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            // Load
            Accommodation accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);
            
            // Do
            var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate);

            // Save
            _repository.UpdateBooking(booking, updateBookingDto.RowVersion);


            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.CreateReview(CreateReviewDto createReviewDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            //load
            Accommodation accommodation = _repository.GetAccommodation(createReviewDto.AccommodationId);
            Guest guest = _guestRepository.GetGuest(createReviewDto.GuestId);

            //do
            accommodation.CreateReview(createReviewDto.Description, createReviewDto.Rating, guest);

            //save
            _repository.AddReview();

            _unitOfWork.Commit();

        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}