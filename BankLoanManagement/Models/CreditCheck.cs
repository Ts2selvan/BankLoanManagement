using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class CreditCheck
{
    public int CreditCheckId { get; set; }

    public int CustomerId { get; set; }

    public int CreditScore { get; set; }

    public DateOnly CreditCheckDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
