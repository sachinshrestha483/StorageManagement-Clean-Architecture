using StorageManagement.Core.Domain.Common.Enumerations;
using StorageManagement.Core.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StorageManagement.Presentation.Web.Models.ViewModels
{
    public class UpsertGateEntryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Entry Reference")]
        [Required]
        public string EntryReference { get; set; }
        
        [DisplayName("Check In")]
        public DateTimeOffset CheckIn { get; set; }
        
        [DisplayName("Check Out")]
        public DateTimeOffset CheckOut { get; set; }
        
        public EntryType EntryType { get; set; }
    }
}
