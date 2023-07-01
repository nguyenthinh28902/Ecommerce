using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductVersion
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ProductVersionCode { get; set; } = null!;

    public string ProductVersionName { get; set; } = null!;

    public decimal? SalePrice { get; set; }

    public decimal? PercentageReduction { get; set; }

    public decimal? Price { get; set; }

    public string? ProductVersionDescription { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsHot { get; set; }

    public DateTime? ReleaseTime { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public int? SellNumber { get; set; }

    public int? Views { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductInformation> ProductInformations { get; set; } = new List<ProductInformation>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductVersionColor> ProductVersionColors { get; set; } = new List<ProductVersionColor>();
}
