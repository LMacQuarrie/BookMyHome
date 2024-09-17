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
app.MapPost("/booking", (CreateBookingDto booking, IBookingCommand command) =>
    command.CreateBooking(booking));
app.MapPut("/booking", (UpdateBookingDto booking, IBookingCommand command) =>
    command.UpdateBooking(booking));
app.MapDelete("/booking", ([FromBody] DeleteBookingDto booking, IBookingCommand command) =>
command.DeleteBooking(booking));

//Host
app.MapPost("/host", (CreateHostDto host, IHostCommand command) =>
    command.CreateHost(host));

//accommodation
app.MapGet("/accommodation", (IAccommodationQuery query) => query.GetAccommodations());
app.MapGet("/accommodation/{id}", (int id, IAccommodationQuery query) => query.GetAccommodation(id));
app.MapPost("/accommodation", (CreateAccommodationDto accommodation, IAccommodationCommand command) =>
    command.CreateAccommodation(accommodation));
app.MapPut("/accommodation",
    (UpdateAccommodationDto accommodation, IAccommodationCommand command) =>
        command.UpdateAccommodation(accommodation));
app.MapDelete("/accomodation",
    ([FromBody] DeleteAccommodationDto accommodation, IAccommodationCommand command) =>
        command.DeleteAccommodation(accommodation));

app.MapGet("/accommodations/{accommodationId}/bookings",
    (int accommodationId, IAccommodationQuery query) =>
        query.GetBookingsForAccommodation(accommodationId));


app.Run();