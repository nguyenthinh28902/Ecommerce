using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class BillItem
{
    public int Id { get; set; }

    public int BillId { get; set; }

    public int ProductId { get; set; }

    public int ProductversionId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    public string ProductImage { get; set; } = null!;

    public bool? IsPresent { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? IntoMoney { get; set; }

    public decimal? Promotion { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual Bill Bill { get; set; } = null!;
}
