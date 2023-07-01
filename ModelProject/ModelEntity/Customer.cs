using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public int CustomerAddress { get; set; }

    public string? CustomerEmail { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? CustomerPay { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();
}
