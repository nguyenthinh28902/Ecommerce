using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Product
{
    public int Id { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? SalePrice { get; set; }

    public decimal? PercentageReduction { get; set; }

    public string? Origin { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsHot { get; set; }

    public DateTime? ReleaseTime { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public int? SellNumber { get; set; }

    public string? ProductDescription { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    public virtual ICollection<ProductVersion> ProductVersions { get; set; } = new List<ProductVersion>();

    public virtual ICollection<ProductsCategory> ProductsCategories { get; set; } = new List<ProductsCategory>();

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
}
