using BookMyHome.Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BookMyHome.Domain.Test")]

namespace BookMyHome.Domain.Entity
{
    public class Booking
    {
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        public static Booking Create(DateOnly startDate, DateOnly endDate, ICheckBooking checkBooking,
            IEnumerable<Booking> otherBookings)
        {
            AssureBookingInFuture(startDate, DateOnly.FromDateTime(DateTime.Now));

            AssureStartDateBeforeEndDate(startDate, endDate);

            var booking = new Booking
            {
                StartDate = startDate,
                EndDate = endDate
            };

            checkBooking.IsOverLapping(booking, otherBookings);

            
            return booking;
        }

        // Booking skal være i fremtiden
        internal static void AssureBookingInFuture(DateOnly startDate, DateOnly now)
        {
            if (startDate <= now)
            {
                throw new ArgumentException("Booking skal være i fremtiden");
            }
        }

        // StartDato skal være før EndDato
        internal static void AssureStartDateBeforeEndDate(DateOnly startDate, DateOnly endDate)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException("Startdate skal være før enddate");
            }
        }
    }
}
