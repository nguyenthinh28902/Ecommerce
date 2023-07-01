using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class DeliveryAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? Wards { get; set; }

    public string? DetailedAddress { get; set; }

    public bool? IsDelivery { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
