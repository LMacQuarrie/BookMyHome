using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands.CommandDto
{
    public record CreateAccommodationDto
    {
        public double Price { get; set; }

        public int HostId { get; set; }
    }
}
