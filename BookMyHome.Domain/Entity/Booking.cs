using BookMyHome.Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entity
{
    public class Booking
    {
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        public static Booking Create(DateOnly startDate, DateOnly endDate, ICheckBooking checkBooking,
            IEnumerable<Booking> otherBookings, DateOnly now)
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
        public static void AssureBookingInFuture(DateOnly startDate, DateOnly now)
        {
            //DateOnly.FromDateTime(DateTime.Now)

            if (startDate <= now)
            {
                throw new ArgumentException("Booking skal være i fremtiden");
            }
        }

        // StartDato skal være før EndDato
        public static void AssureStartDateBeforeEndDate(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Startdate skal være før enddate");
            }
        }
    }
}
