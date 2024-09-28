using BookMyHome.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccommodationCommand, AccommodationCommand>();
            services.AddScoped<IHostCommand, HostCommand>();
            return services;
        }
    }
}
