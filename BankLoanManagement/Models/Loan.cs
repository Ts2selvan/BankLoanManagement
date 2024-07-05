using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int CustomerId { get; set; }

    public string LoanType { get; set; } = null!;

    public decimal LoanAmount { get; set; }

    public decimal InterestRate { get; set; }

    public int LoanTerm { get; set; }

    public decimal MonthlyPayment { get; set; }

    public string LoanStatus { get; set; } = null!;

    public DateOnly ApplicationDate { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public DateOnly? CreditedAmountDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
