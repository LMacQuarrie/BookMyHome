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
    public class GuestRepository : IGuestRepository
    {
        private readonly BookMyHomeContext _db;

        public GuestRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        Guest IGuestRepository.GetGuest(int id)
        {
            return _db.Guests
                .Single(g => g.Id == id);
        }
    }
}
