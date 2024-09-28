using BookMyHome.Application.Commands.CommandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Commands
{
    public class HostCommand : IHostCommand
    {
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HostCommand(IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }
        void IHostCommand.CreateHost(CreateHostDto createHostDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Do
                var host = Host.Create(createHostDto.FirstName);

                // Save
                _hostRepository.AddHost(host);

                // Commit to db
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
