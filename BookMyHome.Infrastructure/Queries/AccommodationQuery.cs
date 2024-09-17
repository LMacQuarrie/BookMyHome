using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class AccommodationQuery : IAccommodationQuery
{
    private readonly BookMyHomeContext _db;

    public AccommodationQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    AccommodationDto IAccommodationQuery.GetAccommodation(int id)
    {
        var accommodation = _db.Accommodations.AsNoTracking().Single(a => a.Id == id);

        return new AccommodationDto
        {
            Id = accommodation.Id,
            Price = accommodation.Price,
            RowVersion = accommodation.RowVersion
        };

        //Get Accommodation med bookings
        //var accommodation = _db.Accommodations.Include(a => a.Bookings).AsNoTracking().Single(a => a.Id == id);

        //return new AccommodationDto
        //{
        //    Id = accommodation.Id,
        //    Price = accommodation.Price,
        //    RowVersion = accommodation.RowVersion,
        //    BookingDtos = accommodation.Bookings.Select(b => new BookingDto
        //    {
        //        Id = b.Id,
        //        StartDate = b.StartDate,
        //        EndDate = b.EndDate,
        //        RowVersion = b.RowVersion
        //    }).ToList()
        //};
    }

    IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodations()
    {
        var result = _db.Accommodations.AsNoTracking()
            .Select(a => new AccommodationDto
            {
                Id = a.Id,
                Price = a.Price,
                RowVersion = a.RowVersion
            });
        return result;
    }

    IEnumerable<BookingDto> IAccommodationQuery.GetBookingsForAccommodation(int accommodationId)
    {
        var result = _db.Bookings
            .AsNoTracking()
            .Where(b => b.Accommodation.Id == accommodationId)
            .Select(b => new BookingDto
            {
                Id = b.Id,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                RowVersion = b.RowVersion
            });

        return result;
    }
}