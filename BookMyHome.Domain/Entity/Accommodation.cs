namespace BookMyHome.Domain.Entity;

public class Accommodation : DomainEntity
{
    private readonly List<Booking> _bookings = new List<Booking>();

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

    public IReadOnlyCollection<Booking> Bookings => _bookings;

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

    public void CreateBooking(DateOnly startDate, DateOnly endDate)
    {
        var booking = Booking.Create(startDate, endDate, Bookings);
        _bookings.Add(booking);
    }

    public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, Bookings);
        return booking;
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