﻿using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using OskitAPI.Core.Types;
using OskitAPI.Models.Entity.CompanySpace;
using OskitAPI.Models.Entity.PurchasesSpace;
using OskitAPI.Models.Entity.SalesSpace;
using OskitAPI.Models.Entity.SystemSpace;


namespace OskitAPI.Models.Entity.BankingSpace
{
    public class BankAccount
    {
        public virtual string? Id { get; set; }
        public virtual string? BankName { get; set; }
        public virtual string? AccountNumber { get; set; }
        public virtual string? BranchName { get; set; }
        public virtual string? BranchCode { get; set; }
        public virtual string? SwiftCode { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual bool Active { get; set; }
        public virtual string? CategoryId { get; set; }
        public virtual string? CompanyId { get; set; }
        public virtual string? PaymentMethodId { get; set; }

        [Timestamp, ConcurrencyCheck]
        public virtual byte[]? RowVersion { get; set; }

        public virtual BankAccountCategory? Category { get; set; }
        public virtual Company? Company { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual CompanyDefaultBankAccount? DefaultBankAccount { get; set; }
        public virtual ICollection<SalesReceipt>? SalesReceipts { get; set; }
        public virtual ICollection<PurchaseReceipt>? PurchaseReceipts { get; set; }

        public BankAccount ()
            => Id = Guid.NewGuid().ToString("N");

        public static void BuildModel (ModelBuilder builder)
        {
            builder.Entity<BankAccount>(options =>
            {
                options.ToTable(nameof(BankAccount))
                    .HasKey(p => p.Id)
                    .IsClustered(false);

                options.HasIndex(p => p.CompanyId)
                    .IsClustered();

                options.Property(p => p.Balance)
                    .HasColumnType(ColumnTypes.Monetary);

                options.Property(p => p.RowVersion)
                    .IsRowVersion();

                options.HasOne(p => p.DefaultBankAccount)
                    .WithOne(p => p.BankAccount)
                    .HasForeignKey<CompanyDefaultBankAccount>(p => p.BankAccountId)
                        .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                options.HasMany(p => p.SalesReceipts)
                    .WithOne(p => p.BankAccount)
                    .HasForeignKey(p => p.BankAccountId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                options.HasMany(p => p.PurchaseReceipts)
                    .WithOne(p => p.BankAccount)
                    .HasForeignKey(p => p.BankAccountId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
