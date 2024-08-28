using BookMyHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Test
{
    public class BookingTests
    {
        //[Fact]
        //public void Given_Startdate_In_Future__Then_Booking_Created()
        //{
        //    // Arrange
        //    var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        //    var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2));


        //    var checkBookingMock = new Mock<ICheckBooking>();

        //    // Act
        //    var booking = Booking.Create(startDate, endDate, checkBookingMock.Object, new List<Booking>());


        //    // Assert
        //    Assert.NotNull(booking);
        //}

        [Theory]
        [InlineData("29-08-2024", "28-08-2024")]
        [InlineData("04-12-2024", "28-08-2024")]
        [InlineData("16-04-2026", "28-08-2024")]
        public void Given_StartDate_In_Future__Then_Valid(string startDateString, string nowDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var nowDate = DateOnly.Parse(nowDateString);

            // Act & Assert
            Booking.AssureBookingInFuture(startDate, nowDate);
        }

        [Theory]
        [InlineData("28-08-2024", "28-08-2024")]
        [InlineData("13-03-2024", "28-08-2024")]
        [InlineData("16-04-2021", "28-08-2024")]
        public void Given_StartDate_In_Past__Then_Exception(string startDateString, string nowDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var nowDate = DateOnly.Parse(nowDateString);


            // Act & Assert
            Assert.Throws<ArgumentException>(() => Booking.AssureBookingInFuture(startDate, nowDate));
        }

        [Theory]
        [InlineData("28-08-2024", "28-08-2024")]
        [InlineData("13-03-2014", "24-08-2025")]
        [InlineData("16-04-2021", "08-10-2026")]
        public void Given_StartDate_Before_EndDate__Then_Valid(string startDateString, string endDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var endDate = DateOnly.Parse(endDateString);


            // Act & Assert
            Booking.AssureStartDateBeforeEndDate(startDate, endDate);
        }

        [Theory]
        [InlineData("28-08-2032", "16-07-2024")]
        [InlineData("25-08-2025", "24-08-2025")]
        [InlineData("29-08-2024", "08-01-2024")]
        public void Given_StartDate_After_EndDate__Then_Exception(string startDateString, string endDateString)
        {
            // Arrange
            var startDate = DateOnly.Parse(startDateString);
            var endDate = DateOnly.Parse(endDateString);


            // Act & Assert
            Assert.Throws<ArgumentException>(() => Booking.AssureStartDateBeforeEndDate(startDate, endDate));
        }

    }
}
