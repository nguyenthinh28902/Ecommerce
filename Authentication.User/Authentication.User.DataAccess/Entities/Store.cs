using Authentication.User.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Entities
{
    [Table("Stores", Schema = TableCategory.Store)]
    public class Store : Entity
    {
        public Guid Id { get; set; }
        [Required]
        public string StoreOwer { get; set; }
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
        public string WebsiteURL { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public DateTimeOffset? ApproveAt { get; set; }
        [ForeignKey("StoreOwer")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
