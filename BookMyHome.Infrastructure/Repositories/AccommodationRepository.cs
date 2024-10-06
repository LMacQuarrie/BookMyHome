using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application;
using BookMyHome.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly BookMyHomeContext _db;

        public AccommodationRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return _db.Accommodations
                .Include(a => a.Bookings)
                .ThenInclude(b => b.Guest)
                .Single(a => a.Id == id);
        }
        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
        {
            _db.Accommodations.Add(accommodation);
            _db.SaveChanges();
        }


        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _db.SaveChanges();
        }
        void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _db.Accommodations.Remove(accommodation);
            _db.SaveChanges();
        }

        void IAccommodationRepository.AddBooking()
        {
            _db.SaveChanges();
        }

        void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowVersion)
        {
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _db.SaveChanges();
        }

        void IAccommodationRepository.DeleteBooking(Booking booking, byte[] rowVersion)
        {
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
            // MANGLER I COMMAND
        }

        void IAccommodationRepository.AddReview()
        {
            _db.SaveChanges();
        }
    }
}
