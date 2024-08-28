using BookMyHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Test.Fakes
{
    public class FakeBooking : Booking
    {
        public FakeBooking(DateOnly startDate, DateOnly endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
