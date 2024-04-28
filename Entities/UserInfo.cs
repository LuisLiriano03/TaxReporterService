using System;
using System.Collections.Generic;

namespace TaxReporter.Entities;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? IdentificationCard { get; set; }

    public string? FullName { get; set; }

    public int? Age { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public int? RolId { get; set; }

    public string? JobTitle { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<InvoiceInfo> InvoiceInfos { get; } = new List<InvoiceInfo>();

    public virtual Rol? Rol { get; set; }
}
