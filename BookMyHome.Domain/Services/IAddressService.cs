using BookMyHome.Domain.Entity.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Enum;

namespace BookMyHome.Domain.Services
{
    public interface IAddressService
    {
        Task<ValidStatus> ValidateAddress(Address address);
    }
}
