using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductsCategory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
