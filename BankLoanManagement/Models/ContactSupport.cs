using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class ContactSupport
{
    public int SupportId { get; set; }

    public int CustomerId { get; set; }

    public string ContactMethod { get; set; } = null!;

    public string ContactDetail { get; set; } = null!;

    public DateOnly ContactDate { get; set; }

    public string IssueDescription { get; set; } = null!;

    public string? ResolutionDescription { get; set; }

    public string? Status { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
