using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public virtual ICollection<ContactSupport> ContactSupports { get; set; } = new List<ContactSupport>();

    public virtual ICollection<CreditCheck> CreditChecks { get; set; } = new List<CreditCheck>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
