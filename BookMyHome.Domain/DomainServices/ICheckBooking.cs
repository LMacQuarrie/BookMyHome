using BookMyHome.Domain.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.DomainServices
{
    public interface ICheckBooking
    {
        void IsOverLapping(Booking booking, IEnumerable<Booking> otherBookings);
    }

    public class CheckBooking : ICheckBooking
    {
        public void IsOverLapping(Booking booking, IEnumerable<Booking> otherBookings)
        {
            foreach (var otherBooking in otherBookings)
            {
                if (booking.StartDate <= otherBooking.EndDate && booking.EndDate >= otherBooking.StartDate)
                {
                    throw new ArgumentException("Booking overlapper med en anden booking");
                }
            }
        }
    }
}
