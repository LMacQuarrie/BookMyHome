using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands.CommandDto
{
    public record CreateReviewDto
    {
        public string Description { get; set; }
        public double Rating { get; set; }
        public int AccommodationId { get; set; }
        public int GuestId { get; set; }
    }
}
