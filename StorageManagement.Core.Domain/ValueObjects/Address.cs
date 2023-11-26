using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Domain.ValueObjects
{
    public record Address
    {
        private Address(string Street, string City, string Pincode)
        {
            Street = this.Street;
            City = this.City;
            Pincode = this.Pincode;
        }

        public string Street { get; init; }
        public string City { get; init; }
        public string Pincode { get; init; }

        public static Address? Create(string street, string city, string pincode)
        {
            if (!string.IsNullOrEmpty(pincode))
            {
                if(pincode.Length!=6)
                {
                    return null;
                }
            }
            return new Address(Street: street, City: city, Pincode: pincode);
        }
    }
   
}
