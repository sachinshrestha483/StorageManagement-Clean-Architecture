using StorageManagement.Core.Domain.Common.Abstractions;
using StorageManagement.Core.Domain.Common.Primitives;
using StorageManagement.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public Customer() { }
        public Customer(string name, string pan, Address address, ContactPerson contactPerson)
        {
            Name = name;
            Address = address;
            ContactPerson = contactPerson;
            Pan = pan;
        }
        public CustomerId Id { get; private set; }
        public string Name { get; private set; }
        public string Pan { get; private set; }
        public Address Address { get; private set; }
        public ContactPerson ContactPerson { get; private set; }
        public void Update(string name, string pan, Address address, ContactPerson contactPerson)
        {
            Name = name;
            Pan = pan;
            Address = address;
            ContactPerson = contactPerson;
        }

    }
}
