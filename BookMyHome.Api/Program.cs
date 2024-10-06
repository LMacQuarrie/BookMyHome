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
app.MapGet("/accommodation/{id}/booking", (int accommodationId, IBookingQuery query) => query.GetBookings(accommodationId));
app.MapGet("/accommodation/{accommodationId}/booking/{bookingId}", (int accommodationId, int bookingId, IBookingQuery query) => query.GetBooking(accommodationId, bookingId));
app.MapPost("/accommodation/booking", (CreateBookingDto booking, IAccommodationCommand command) => command.CreateBooking(booking));
app.MapPut("/accommodation/booking", (UpdateBookingDto booking, IAccommodationCommand command) => command.UpdateBooking(booking));

//
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

//bookings for accommodation
app.MapGet("/host/{id}/accommodation",
    (int hostId, IHostQuery query) =>
        query.GetAccommodations(hostId));

//reviews for hostens accommodations



//Host
app.MapPost("/host", (CreateHostDto host, IHostCommand command) =>
    command.CreateHost(host));

//Review
app.MapPost("/accommodation/Review",
    (CreateReviewDto review, IAccommodationCommand command) => command.CreateReview(review));

app.Run();