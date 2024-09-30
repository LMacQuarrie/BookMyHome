using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries
{
    public class HostQuery : IHostQuery
    {
        private readonly BookMyHomeContext _db;

        public HostQuery(BookMyHomeContext db)
        {
            _db = db;
        }
        HostDto? IHostQuery.GetAccommodations(int hostId)
        {
            var host = _db.Hosts
                .Include(a => a.Accommodations)
                .ThenInclude(a => a.Bookings)
                .Include(a => a.Accommodations)
                .ThenInclude(a => a.Reviews)
                .FirstOrDefault(h => h.Id == hostId);

            if (host == null) return null;

            return new HostDto
            {
                Id = host.Id,
                FirstName = host.FirstName,
                Accommodations = host.Accommodations.Select(a => new AccommodationDto
                {
                    Id = a.Id,
                    HostId = a.Host.Id,
                    Bookings = a.Bookings.Select(b => new BookingDto
                    {
                        Id = b.Id,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        RowVersion = b.RowVersion
                    }),
                    Reviews = a.Reviews.Select(r => new ReviewDto
                    {
                        Id = r.Id,
                        Description = r.Description,
                        Rating = r.Rating,
                        RowVersion = r.RowVersion
                    })
                })
            };
        }

        IEnumerable<HostDto> IHostQuery.GetAllHosts()
        {
            throw new NotImplementedException();
        }

        HostDto IHostQuery.GetHost(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
