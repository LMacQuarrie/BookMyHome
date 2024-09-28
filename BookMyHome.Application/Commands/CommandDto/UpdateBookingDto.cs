namespace BookMyHome.Application.Commands.CommandDto;

public record UpdateBookingDto
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public byte[] RowVersion { get; set; }
    public int AccommodationId { get; set; }    
}