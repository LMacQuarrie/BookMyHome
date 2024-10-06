using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Enum;
using BookMyHome.Domain.Services;

namespace BookMyHome.Domain.Entity.ValueObjects
{
    public class Address
    {
        public string Street { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string City { get; protected set; }
        public string PostalCode { get; protected set; }
        public string? Floor { get; protected set; }
        public string? Door { get; protected set; }

        public ValidStatus ValidStatus { get; protected set; } = ValidStatus.Pending;

        protected Address(){}
        private Address(string street, string houseNumber, string city, string postalCode, string? floor, string? door)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            Floor = floor;
            Door = door;
        }

        public static Address Create(string street, string houseNumber, string city, string postalCode, string? floor,
            string? door)
        {
            return new Address(street, houseNumber, city, postalCode, floor, door);
        }

        public async Task ValidateAddress(IAddressService addressService)
        {
            ValidStatus validStatus = await addressService.ValidateAddress(this);
            if (validStatus == ValidStatus.Invalid)
            {
                throw new ArgumentException("Ugyldig Addresse");
            }

            ValidStatus = validStatus;
        }
    }
}
