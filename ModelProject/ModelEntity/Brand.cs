using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Brand
{
    public int Id { get; set; }

    public string BrandCode { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public string Brandlogo { get; set; } = null!;

    public string Brandimages { get; set; } = null!;

    public string? BrandDescription { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? Views { get; set; }

    public virtual ICollection<BrandsCategory> BrandsCategories { get; set; } = new List<BrandsCategory>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
