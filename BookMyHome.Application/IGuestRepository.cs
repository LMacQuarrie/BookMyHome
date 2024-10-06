using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application
{
    public interface IGuestRepository
    {
        Guest GetGuest(int id);
    }
}
