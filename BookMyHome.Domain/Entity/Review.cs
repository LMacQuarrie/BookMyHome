using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entity
{
    public class Review : DomainEntity
    {
        public string Description { get; protected set; }
        public double Rating { get; protected set; }

        // nav
        public Accommodation Accommodation { get; protected set; }
        public Guest Guest { get; protected set; }

        protected Review() { }

        private Review(string description, double rating, Guest guest, IReadOnlyCollection<Booking> bookings)
        {
            Description = description;
            Rating = rating;
            Guest = guest;
            AssureBookingStartingInPast(DateOnly.FromDateTime(DateTime.Now), bookings);
        }

        public static Review Create(string description, double rating, Guest guest, IReadOnlyCollection<Booking> bookings)
        {
            return new Review(description, rating, guest, bookings);
        }

        protected void AssureBookingStartingInPast(DateOnly now, IReadOnlyCollection<Booking> bookings)
        {
            if (!bookings.Any(b => b.Guest.Id == Guest.Id && b.StartDate < now))
            {
                throw new ArgumentException("Du skal have en booking med startdato i fortiden");
            }

        }
    }
}
