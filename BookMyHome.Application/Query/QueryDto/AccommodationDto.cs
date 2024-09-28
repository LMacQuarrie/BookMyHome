using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Query.QueryDto
{
    public record AccommodationDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public byte[] RowVersion { get; set; }

        public IEnumerable<BookingDto>? Bookings { get; set; }
        public int HostId { get; set; }
    }
}
