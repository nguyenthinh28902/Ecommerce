using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductColor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ColorName { get; set; } = null!;

    public string ImageColorProduct { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? ColorDescription { get; set; }

    public int? SellNumber { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual Product Product { get; set; } = null!;
}
