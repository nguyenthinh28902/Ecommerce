using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class IndustryInformation
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? IndustryInformationCode { get; set; }

    public string IndustryInformationName { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<IndustryInformationDetail> IndustryInformationDetails { get; set; } = new List<IndustryInformationDetail>();
}
