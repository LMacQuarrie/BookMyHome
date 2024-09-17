namespace BookMyHome.Application.Commands.CommandDto;

public record DeleteBookingDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; }
}