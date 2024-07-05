using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public int LoanId { get; set; }

    public string DocumentType { get; set; } = null!;

    public DateOnly UploadedAt { get; set; }

    public virtual Loan Loan { get; set; } = null!;
}
