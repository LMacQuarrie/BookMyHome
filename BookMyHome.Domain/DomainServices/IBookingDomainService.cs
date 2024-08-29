﻿using BookMyHome.Domain.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<Booking> GetOtherBookings(Booking booking);
    }

    public class BookingDomainService : IBookingDomainService
    {
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
