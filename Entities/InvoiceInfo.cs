using System;
using System.Collections.Generic;

namespace TaxReporter.Entities;

public partial class InvoiceInfo
{
    public int InvoiceId { get; set; }

    public int? UserId { get; set; }

    public DateTime? IssueDate { get; set; }

    public string? BusinessName { get; set; }

    public string? Rnc { get; set; }

    public string? Nfc { get; set; }

    public decimal? AmountWithoutItbis { get; set; }

    public decimal? Itbis { get; set; }

    public decimal? ServicePercentage { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? ImageUrl { get; set; }

    public int? StateId { get; set; }

    public virtual InvoiceState? State { get; set; }

    public virtual UserInfo? User { get; set; }
}
