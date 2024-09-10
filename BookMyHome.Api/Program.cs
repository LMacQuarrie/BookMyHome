using BookMyHome.Application;
using BookMyHome.Application.Commands;
using BookMyHome.Application.Commands.CommandDto;
using BookMyHome.Application.Query;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Infrastructure;
using BookMyHome.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

app.MapGet("/booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
app.MapPost("/booking",
    (CreateBookingDto createBookingDto, IBookingCommand bookingCommand) =>
        bookingCommand.CreateBooking(createBookingDto));
app.MapPut("/booking",
    (UpdateBookingDto updateBookingDto, IBookingCommand bookingCommand) =>
        bookingCommand.UpdateBooking(updateBookingDto));
app.MapDelete("/booking",
    ([FromBody] DeleteBookingDto deleteBookingDto, IBookingCommand BookingCommand) =>
        BookingCommand.DeleteBooking(deleteBookingDto));


app.Run();







//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}









//builder.Services.AddScoped<IBookingRepository, BookingRepository>();
//builder.Services.AddScoped<IBookingCommand, BookingCommand>();
//builder.Services.AddScoped<IBookingQuery, BookingQuery>();
//builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();


////Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
////Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
//builder.Services.AddDbContext<BookMyHomeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookMyHomeDbConnection"),
//    x => x.MigrationsAssembly("BookMyHome.DatabaseMigration")));