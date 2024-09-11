using BookMyHome.Application.Query;
using BookMyHome.Application;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookingQuery, BookingQuery>();
            services.AddScoped<IBookingDomainService, BookingDomainService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
            {
                var db = p.GetService<BookMyHomeContext>();
                return new UnitOfWork(db);
            });

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
