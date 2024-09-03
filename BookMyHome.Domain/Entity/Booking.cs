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
        public int Id { get; protected set; }
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        protected Booking() { }

        private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
        {
            AssureBookingInFuture(DateOnly.FromDateTime(DateTime.Now));

            StartDate = startDate;
            EndDate = endDate;

            AssureStartDateBeforeEndDate();

            StartDate = startDate;
            EndDate = endDate;

            AssureNoOverLapping(bookingDomainService.GetOtherBookings(this));
        }

        public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService,
            IEnumerable<Booking> otherBookings)
        {
            return new Booking(startDate, endDate, bookingDomainService);
        }


        protected void AssureBookingInFuture(DateOnly now)
        {
            if (StartDate <= now)
            {
                throw new ArgumentException("Booking skal være i fremtiden");
            }
        }

        // StartDato skal være før EndDato
        protected void AssureStartDateBeforeEndDate()
        {
            if (StartDate >= EndDate)
            {
                throw new ArgumentException("Startdate skal være før enddate");
            }
        }

        protected void AssureNoOverLapping(IEnumerable<Booking> otherBookings)
        {
            foreach (var otherBooking in otherBookings)
            {
                if (this.StartDate <= otherBooking.EndDate && this.EndDate >= otherBooking.StartDate)
                {
                    throw new ArgumentException("Booking overlapper med en anden booking");
                }
            }
        }
    }
}






//public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService,
//    IEnumerable<Booking> otherBookings)
//{
//    AssureBookingInFuture(startDate, DateOnly.FromDateTime(DateTime.Now));

//    AssureStartDateBeforeEndDate(startDate, endDate);

//    var booking = new Booking
//    {
//        StartDate = startDate,
//        EndDate = endDate
//    };

//    bookingDomainService.AssureNoOverLapping(booking, otherBookings);


//    return booking;
//}

// Booking skal være i fremtiden