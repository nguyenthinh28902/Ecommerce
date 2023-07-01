using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductVersionColor
{
    public int Id { get; set; }

    public int ProductColors { get; set; }

    public int ProductVersionId { get; set; }

    public string ImageColorProduct { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? ColorDescription { get; set; }

    public int? SellNumber { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public int? Views { get; set; }

    public virtual ProductVersion ProductVersion { get; set; } = null!;

    public virtual ICollection<Quantity> Quantities { get; set; } = new List<Quantity>();
}
