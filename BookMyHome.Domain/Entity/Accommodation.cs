using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.DomainServices;

namespace BookMyHome.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public double Price { get; set; }
        public Host Host { get; protected set; }

        public IEnumerable<Booking> Bookings { get; set; }

        protected Accommodation() { }

        private Accommodation(double price)
        {
            Price = price;
            AssurePriceOverZero();
        }

        
        public static Accommodation Create(double price)
        {
            return new Accommodation(price);
        }

        // Prisen skal være over 0
        protected void AssurePriceOverZero()
        {
            if(Price <= 0)
            {
                throw new ArgumentException("Prisen skal være over 0kr");
            }
        }

        protected void AssureNoBookingInFuture()
        {
            var result = Bookings.Any(b => b.StartDate >= DateOnly.FromDateTime(DateTime.Now));
            if (result)
            {
                throw new ArgumentException("Du må ikke slette en Accommodation med en fremtidig booking");
            }
        }

        protected void Delete()
        {
            AssureNoBookingInFuture();
        }
    }
}
