using BookMyHome.Application.Commands.CommandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Helpers;

namespace BookMyHome.Application.Commands
{

    public class AccommodationCommand : IAccommodationCommand
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostRepository _hostRepository;

        public AccommodationCommand(IAccommodationRepository accommodationRepository, IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
            _hostRepository = hostRepository;
        }
        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var host = _hostRepository.GetHost(createAccommodationDto.HostId);

                // Do
                var accommodation = Accommodation.Create(createAccommodationDto.Price, host);

                // Save
                _accommodationRepository.AddAccommodation(accommodation);

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
            throw new NotImplementedException();
        }

        void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
        {
            throw new NotImplementedException();
        }
    }
}
