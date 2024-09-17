using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application;
using BookMyHome.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly BookMyHomeContext _db;

        public HostRepository(BookMyHomeContext context)
        {
            _db = context;
        }
        void IHostRepository.AddHost(Host host)
        {
            _db.Hosts.Add(host);
            _db.SaveChanges();
        }

        void IHostRepository.DeleteHost(Host host, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }

        Host IHostRepository.GetHost(int id)
        {
            return _db.Hosts
                .Include(h => h.Accommodations)
                    .ThenInclude(a => a.Bookings)
                .Single(h => h.Id == id);
        }

        void IHostRepository.UpdateHost(Host host, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }
    }
}
