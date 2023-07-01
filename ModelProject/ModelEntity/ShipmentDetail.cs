using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class ShipmentDetail
{
    public int Id { get; set; }

    public int BillId { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string? City { get; set; }

    public string? District { get; set; }

    public string? Wards { get; set; }

    public string? DetailedAddress { get; set; }

    public string DeliveryStatus { get; set; } = null!;

    public string? Delivery { get; set; }

    public DateTime? DeliveryTime { get; set; }

    public int Shipper { get; set; }

    public string? DeliveryReviews { get; set; }

    public int? SatisfactionLevel { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Bill Bill { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
