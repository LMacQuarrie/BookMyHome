using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Query.QueryDto
{
    public record HostDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public byte[] RowVersion { get; set; }

        public required IEnumerable<AccommodationDto> Accommodations { get; set; }
    }
}
