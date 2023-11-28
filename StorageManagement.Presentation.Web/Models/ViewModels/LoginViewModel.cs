using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NuGet.Protocol.Core.Types;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StorageManagement.Presentation.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        public bool RememberMe { get; set; }
        
        public string? RedirectUrl { get; set; }
    }
}
