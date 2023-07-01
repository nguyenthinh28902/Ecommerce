using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ProductInformation
{
    public int Id { get; set; }

    public int IndustryInformationDetailId { get; set; }

    public int ProductVersionId { get; set; }

    public string ProductInformationValue { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual IndustryInformationDetail IndustryInformationDetail { get; set; } = null!;

    public virtual ProductVersion ProductVersion { get; set; } = null!;
}
