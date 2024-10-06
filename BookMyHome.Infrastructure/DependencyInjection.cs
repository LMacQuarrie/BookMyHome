using BookMyHome.Application.Query;
using BookMyHome.Application;
using BookMyHome.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Services;
using Microsoft.EntityFrameworkCore;
using BookMyHome.Infrastructure.Repositories;
using BookMyHome.Infrastructure.Services;

namespace BookMyHome.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookingQuery, BookingQuery>();
            services.AddScoped<IAccommodationQuery, AccommodationQuery>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IHostQuery, HostQuery>();
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();
            services.AddScoped<IGuestRepository, GuestRepository>();

            services.AddHttpClient<IAddressService, AddressService>(client =>
                client.BaseAddress = new Uri(configuration["BMH.AddressServiceBaseUrl"]));


            // Database
            // https://github.com/dotnet/SqlClient/issues/2239
            // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
            // Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
            // Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
            services.AddDbContext<BookMyHomeContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString
                        ("BookMyHomeDbConnection"),
                    x =>
                        x.MigrationsAssembly("BookMyHome.DatabaseMigration")));
            return services;
        }
    }
}
