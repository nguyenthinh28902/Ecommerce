using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductReview
{
    public int Id { get; set; }

    public int ProductVersionId { get; set; }

    public int? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string? CustomerEmail { get; set; }

    public int ProductRating { get; set; }

    public string? Productreview1 { get; set; }

    public bool? IsEdit { get; set; }

    public bool? IsDelete { get; set; }

    public int? Agree { get; set; }

    public int? Protest { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ProductVersion ProductVersion { get; set; } = null!;
}
