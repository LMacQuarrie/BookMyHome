namespace BookMyHome.Domain.Entity;

public class Accommodation : DomainEntity
{
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

    public List<Booking> Bookings { get; protected set; }


    public static Accommodation Create(double price, Host host)
    {
        return new Accommodation(price, host);
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

    public void Update(double price)
    {
        Price = price;
        AssurePriceOverZero();
    }


    public void Delete()
    {
        AssureNoBookingInFuture();
    }
}