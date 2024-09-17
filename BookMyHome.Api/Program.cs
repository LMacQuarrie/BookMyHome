using BookMyHome.Application;
using BookMyHome.Application.Commands;
using BookMyHome.Application.Commands.CommandDto;
using BookMyHome.Application.Query;
using BookMyHome.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Application and Infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hello world");


//Booking
app.MapGet("/booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
app.MapPost("/booking", (CreateBookingDto createBookingDto, IBookingCommand bookingCommand) =>
    bookingCommand.CreateBooking(createBookingDto));
app.MapPut("/booking", (UpdateBookingDto updateBookingDto, IBookingCommand bookingCommand) =>
    bookingCommand.UpdateBooking(updateBookingDto));
app.MapDelete("/booking", ([FromBody] DeleteBookingDto deleteBookingDto, IBookingCommand BookingCommand) =>
BookingCommand.DeleteBooking(deleteBookingDto));

app.MapPost("/host", (CreateHostDto createHostDto, IHostCommand hostCommand) =>
    hostCommand.CreateHost(createHostDto));

app.MapGet("/accommodation", (IAccommodationQuery query) => query.GetAccommodations());
app.MapGet("/accommodation/{id}", (int id, IAccommodationQuery query) => query.GetAccommodation(id));
app.MapPost("/accommodation", (CreateAccommodationDto createAccommodationDto, IAccommodationCommand accommodationCommand) =>
    accommodationCommand.CreateAccommodation(createAccommodationDto));
app.MapPut("/accommodation",
    (UpdateAccommodationDto updateAccommodationDto, IAccommodationCommand accommodationCommand) =>
        accommodationCommand.UpdateAccommodation(updateAccommodationDto));
app.MapDelete("/accomodation", ([FromBody] DeleteAccommodationDto deleteAcommodationDto, IAccommodationCommand acommodationCommand) =>
    acommodationCommand.DeleteAccommodation(deleteAcommodationDto));

    app.MapGet("/accommodations/{accommodationId}/bookings", (int accommodationId, IAccommodationQuery accommodationQuery) =>
       accommodationQuery.GetBookingsForAccommodation(accommodationId));

app.Run();

