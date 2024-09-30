using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BookMyHome.Domain.Test")]

namespace BookMyHome.Domain.Entity
{
    public class Booking : DomainEntity
    {
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        //nav prop
        public Accommodation Accommodation { get; protected set; }
        public Guest Guest { get; set; }

        protected Booking() { }

        private Booking(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings, Guest guest)
        {
            StartDate = startDate;
            EndDate = endDate;
            Guest = guest;
            AssureBookingInFuture(DateOnly.FromDateTime(DateTime.Now));
            AssureStartDateBeforeEndDate();
            AssureNoOverLapping(existingBookings);
        }

        public static Booking Create(DateOnly startDate, DateOnly endDate
            , IEnumerable<Booking> existingBookings, Guest guest)
        {
            return new Booking(startDate, endDate, existingBookings, guest);
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

        public void Update(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
        {
            StartDate = startDate;
            EndDate = endDate;
            AssureBookingInFuture(DateOnly.FromDateTime(DateTime.Now));
            AssureStartDateBeforeEndDate();
            AssureNoOverLapping(existingBookings);
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