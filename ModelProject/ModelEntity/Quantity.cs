using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Quantity
{
    public int Id { get; set; }

    public int ProductVersionColorId { get; set; }

    public int? Quantity1 { get; set; }

    public int? SellNumber { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual ProductVersionColor ProductVersionColor { get; set; } = null!;
}
