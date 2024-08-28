using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Test.Fakes;

namespace BookMyHome.Domain.Test
{
    public class CheckBookingTests
    {
        [Theory]
        [InlineData("10-04-2020", "14-04-2020")]
        [InlineData("16-08-2024", "19-08-2024")] 
        [InlineData("12-09-2024", "17-09-2024")]
        [InlineData("17-03-2025", "24-03-2025")]
        public void Given_That_Bookings_Dont_OverLap__Then_Valid(string startDateString, string endDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var endDate = DateOnly.Parse(endDateString);

            var booking = new FakeBooking(startDate, endDate);


            var otherBookings = new List<Booking>
            {
                new FakeBooking(DateOnly.Parse("20-08-2024"), DateOnly.Parse("10-09-2024")),
                new FakeBooking(DateOnly.Parse("17-12-2024"), DateOnly.Parse("24-12-2024"))
            };

            var sut = new CheckBooking();

            // Act & Assert

            sut.IsOverLapping(booking, otherBookings);
        }

        [Theory]
        [InlineData("26-08-2024", "28-08-2024")]
        [InlineData("29-08-2024", "05-09-2024")]
        [InlineData("30-08-2024","10-09-2024")]
        [InlineData("25-08-2024", "10-09-2024")]
        public void Given_That_Bookings_OverLap__Then_Exception(string startDateString, string endDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var endDate = DateOnly.Parse(endDateString);

            var booking = new FakeBooking(startDate, endDate);


            var otherBookings = new List<Booking>
            {
                new FakeBooking(DateOnly.Parse("28-08-2024"), DateOnly.Parse("06-09-2024"))
            };

            var sut = new CheckBooking();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.IsOverLapping(booking, otherBookings));

        }
    }
}
