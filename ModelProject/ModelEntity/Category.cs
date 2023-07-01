using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryImage { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsHot { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? Views { get; set; }

    public virtual ICollection<BrandsCategory> BrandsCategories { get; set; } = new List<BrandsCategory>();

    public virtual ICollection<IndustryInformation> IndustryInformations { get; set; } = new List<IndustryInformation>();

    public virtual ICollection<ProductsCategory> ProductsCategories { get; set; } = new List<ProductsCategory>();
}
