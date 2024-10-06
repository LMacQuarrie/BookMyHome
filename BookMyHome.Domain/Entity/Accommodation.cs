using BookMyHome.Domain.Entity.ValueObjects;
using BookMyHome.Domain.Services;
using System.Drawing;
using System.IO;

namespace BookMyHome.Domain.Entity;

public class Accommodation : DomainEntity
{
    private readonly List<Booking> _bookings = new List<Booking>();
    private readonly List<Review> _reviews = new List<Review>();

    protected Accommodation()
    {
    }

    private Accommodation(double price, Host host)
    {
        Price = price;
        Host = host;

        AssurePriceOverZero();
    }

    public double Price { get; protected set; }
    public Host Host { get; protected set; }

    public Address Address { get; protected set; }

    public IReadOnlyCollection<Booking> Bookings => _bookings;
    public IReadOnlyCollection<Review> Reviews => _reviews;

    public static Accommodation Create(double price, Host host)
    {
        return new Accommodation(price, host);
    }

    public void Update(double price)
    {
        Price = price;
        AssurePriceOverZero();
    }


    public void Delete()
    {
        AssureNoBookingInFuture();
    }

    public async Task AddAddress(string street, string houseNumber, string city, string postalCode, string? floor,
        string? door, IAddressService addressService)
    {
        var address = Address.Create(street, houseNumber, city, postalCode, floor, door);
        try
        {
            await address.ValidateAddress(addressService);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Kan ikke forbinde til Address Service Api");
        }
        Address = address;
    }

    public void CreateBooking(DateOnly startDate, DateOnly endDate, Guest guest)
    {
        var booking = Booking.Create(startDate, endDate, Bookings, guest);
        _bookings.Add(booking);
    }

    public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, Bookings);
        return booking;
    }

    public void CreateReview(string description, double rating, Guest guest)
    {
        var review = Review.Create(description, rating, guest, Bookings);
        _reviews.Add(review);
    }


    // Prisen skal være over 0
    protected void AssurePriceOverZero()
    {
        if (Price <= 0) throw new ArgumentException("Prisen skal være over 0kr");
    }

    protected void AssureNoBookingInFuture()
    {
        var result = Bookings.Any(b => b.StartDate >= DateOnly.FromDateTime(DateTime.Now));
        if (result) throw new ArgumentException("Du må ikke slette en Accommodation med en fremtidig booking");
    }
}