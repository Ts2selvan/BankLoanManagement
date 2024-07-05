using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class LoanType
{
    public int LoanTypeId { get; set; }

    public string LoanTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal MaxLoanAmount { get; set; }

    public decimal InterestRate { get; set; }

    public int MaxTerm { get; set; }
}
