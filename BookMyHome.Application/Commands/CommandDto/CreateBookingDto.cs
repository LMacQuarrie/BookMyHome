﻿namespace BookMyHome.Application.Commands.CommandDto;

public record CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public int AccommodationId { get; set; }
    public int GuestId { get; set; }
}