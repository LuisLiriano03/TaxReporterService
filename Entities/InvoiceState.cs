namespace TaxReporter.Entities;

public partial class InvoiceState
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<InvoiceInfo> InvoiceInfos { get; } = new List<InvoiceInfo>();
}
