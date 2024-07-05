using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class LoanApplication
{
    public int ApplicationId { get; set; }

    public int LoanId { get; set; }

    public string ApplicationStatus { get; set; } = null!;

    public DateOnly StatusChangeDate { get; set; }

    public string? Comments { get; set; }

    public virtual Loan Loan { get; set; } = null!;
}
