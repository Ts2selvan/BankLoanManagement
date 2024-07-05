using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.Models;

public partial class BankLoanDbContext : DbContext
{
    public BankLoanDbContext()
    {
    }

    public BankLoanDbContext(DbContextOptions<BankLoanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactSupport> ContactSupports { get; set; }

    public virtual DbSet<CreditCheck> CreditChecks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanApplication> LoanApplications { get; set; }

    public virtual DbSet<LoanType> LoanTypes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I63JLBO\\MSSQLSERVER01;Database=BankLoanApplication;User ID=sa;Password=sa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactSupport>(entity =>
        {
            entity.HasKey(e => e.SupportId).HasName("PK__ContactS__D82DBC6CF9E4AA19");

            entity.ToTable("ContactSupport");

            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.ContactDetail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.IssueDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResolutionDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Open");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContactSupports)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactSu__Custo__4CA06362");
        });

        modelBuilder.Entity<CreditCheck>(entity =>
        {
            entity.HasKey(e => e.CreditCheckId).HasName("PK__CreditCh__7D6094338E52851F");

            entity.Property(e => e.CreditCheckId).HasColumnName("CreditCheckID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.CreditChecks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CreditChe__Custo__46E78A0C");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8DB1324D4");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6F32FFAB94");

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoanId).HasColumnName("LoanID");

            entity.HasOne(d => d.Loan).WithMany(p => p.Documents)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documents__LoanI__3E52440B");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD43778C4717C");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoanStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoanType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyPayment).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Loans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__CustomerI__3B75D760");
        });

        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__LoanAppl__C93A4F7967B6BC42");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoanId).HasColumnName("LoanID");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoanAppli__LoanI__440B1D61");
        });

        modelBuilder.Entity<LoanType>(entity =>
        {
            entity.HasKey(e => e.LoanTypeId).HasName("PK__LoanType__19466B4F3FC3E860");

            entity.Property(e => e.LoanTypeId).HasColumnName("LoanTypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoanTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaxLoanAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58D88DAA45");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Loan).WithMany(p => p.Payments)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__LoanID__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC0CEFACD2");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
