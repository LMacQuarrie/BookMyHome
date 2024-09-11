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
        void CreateAccommodation(CreateAccommodationDto createAccommodationDto);
        void UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto);
        void DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto);

    }
}
