using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class Account
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? AccountName { get; set; }

    public string? BankName { get; set; }

    public string? AccountType { get; set; }

    public string? AccountNumber { get; set; }

    public bool? IsPay { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
