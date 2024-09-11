using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entity
{
    public class Host : DomainEntity
    {
        public string FirstName { get; protected set; }
        public List<Accommodation> Accommodations { get; protected set; }

        protected Host() { }

        private Host(string firstName)
        {
            FirstName = firstName;
        }

        public static Host Create(string firstName)
        {
            return new Host(firstName);
        }
    }

    
}
