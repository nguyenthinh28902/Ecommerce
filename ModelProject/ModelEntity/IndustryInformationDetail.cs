using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class IndustryInformationDetail
{
    public int Id { get; set; }

    public int IndustryInformationId { get; set; }

    public string? IndustryInformationDetailCode { get; set; }

    public string IndustryInformationDetailName { get; set; } = null!;

    public string? DataProductInformationCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual IndustryInformation IndustryInformation { get; set; } = null!;

    public virtual ICollection<ProductInformation> ProductInformations { get; set; } = new List<ProductInformation>();
}
