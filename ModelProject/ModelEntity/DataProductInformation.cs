using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class DataProductInformation
{
    public int Id { get; set; }

    public string DataProductInformationCode { get; set; } = null!;

    public string DataProductInformationName { get; set; } = null!;

    public string DataProductInformationValue { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }
}
