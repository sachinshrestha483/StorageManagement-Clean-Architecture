using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StorageManagement.Presentation.Web.Models.ViewModels
{
    public class UpsertCustomerViewModel
    {
        public int Id { get; set;}
        
        public string Name { get; set; }

        public string Pan { get; set; }
        
        [DisplayName("Address City")]
        public string? AddressCity { get; set; }
        
        [DisplayName("Address Street")]
        public string? AddressStreet{ get; set; }
        
        [DisplayName("Address Pincode")]
        public string? AddressPincode { get; set; }
        
        [DisplayName("Contact Person Name")]
        public string? ContactPersonName { get; set; }
        
        [DisplayName("Contact Person Phone")]
        public string? ContactPersonPhone { get; set; }
    }
}
