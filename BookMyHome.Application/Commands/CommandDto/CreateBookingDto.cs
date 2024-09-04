namespace BookMyHome.Application.Commands.CommandDto;

public class CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}