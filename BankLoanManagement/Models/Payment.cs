using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int LoanId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal AmountPaid { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Loan Loan { get; set; } = null!;
}
