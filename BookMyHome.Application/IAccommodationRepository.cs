using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application
{
    public interface IAccommodationRepository
    {
        Accommodation GetAccommodation(int id);
        void AddAccommodation(Accommodation accommodation);
        void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion);
        void DeleteAccommodation(Accommodation accommodation, byte[] rowVersion);
    }
}
