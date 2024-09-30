using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entity
{
    public class Guest : DomainEntity
    {

        // nav
        public IEnumerable<Booking> Bookings { get; protected set; }
        public IEnumerable<Review> Reviews { get; protected set; }
    }
}
