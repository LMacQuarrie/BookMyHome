using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entity
{
    public class Host : DomainEntity
    {
        public IEnumerable<Accommodation> Accommodations { get; protected set; }
    }
}
