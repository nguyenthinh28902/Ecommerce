using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.ViewModels.StoreViewModels
{
    public class StoreViewModel
    {

        public Guid Id { get; set; }        
        public string Logo { get; set; }
        public string Name { get; set; }
        [Required]
        public string TaxCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Url]
        public string WebsiteURL { get; set; } 
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class RegisterStoreViewModel
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        [Required]
        public string TaxCode { get; set; }
        [Phone]
        [DisplayName("SDT")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Url]
        public string WebsiteURL { get; set; }
    }
}
