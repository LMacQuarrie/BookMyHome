using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands.CommandDto
{
    public record UpdateAccommodationDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
