using StorageManagement.Core.Domain.Common.Abstractions;
using StorageManagement.Core.Domain.Common.Enumerations;
using StorageManagement.Core.Domain.Common.Primitives;
using StorageManagement.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Domain.Entities
{
    public class GateEntry : BaseAuditableEntity
    {
        public GateEntry()
        {
        }
        public GateEntry(string entryReference, DateTimeOffset checkIn, DateTimeOffset checkOut, EntryType entryType)
        {
            if(checkIn>checkOut)
            {
                checkOut = checkIn;
            }
            EntryReference = entryReference;
            EntryType = entryType;
            CheckIn = checkIn;
            CheckOut = checkOut;
            EntryType = entryType;
        }

        public GateEntryId Id { get; private set; }
        public string EntryReference { get; private set; }
        public DateTimeOffset CheckIn { get; private set; }
        public DateTimeOffset CheckOut { get; private set; }
        public EntryType EntryType { get; private set; }
        public void Update(string entryReference,DateTimeOffset checkIn,DateTimeOffset checkOut, EntryType entryType)
        {
            EntryReference = entryReference;
            CheckIn = checkIn;
            CheckOut = checkOut;
            EntryType = entryType;
        }
    }
}
