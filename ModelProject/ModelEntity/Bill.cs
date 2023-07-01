using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Bill
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? AccountName { get; set; }

    public string? BankName { get; set; }

    public string? AccountType { get; set; }

    public string? AccountNumber { get; set; }

    public string? PaymentMethods { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? IntoMoney { get; set; }

    public decimal? Promotion { get; set; }

    public decimal? TotalAmountOfGiftPromotion { get; set; }

    public bool? IsCancel { get; set; }

    public bool IsPaymentStatus { get; set; }

    public bool? IsGiveAgift { get; set; }

    public string DeliveryStatus { get; set; } = null!;

    public DateTime? PaymentTime { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CreateUser { get; set; }

    public virtual ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();
}
