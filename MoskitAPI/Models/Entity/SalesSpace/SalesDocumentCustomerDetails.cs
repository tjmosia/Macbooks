﻿using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using Moskit.Models.Entity.CustomerSpace;

namespace Moskit.Models.Entity.SalesSpace
{
    public class SalesDocumentCustomerDetails
    {
        public virtual string? Id { get; set; }
        public virtual string? CustomerId { get; set; }
        public virtual string? CustomerName { get; set; }
        public virtual string? BillingAddress { get; set; }
        public virtual string? ShippingAddress { get; set; }
        public virtual string? VATNumber { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool Active { get; set; }

        [Timestamp, ConcurrencyCheck]
        public virtual byte[]? RowVersion { get; set; }
        public virtual Customer? Customer { get; set; }

        public SalesDocumentCustomerDetails ()
            => Id = Guid.NewGuid().ToString("N");

        public static void BuildModel (ModelBuilder builder)
            => builder.Entity<SalesDocumentCustomerDetails>(options =>
            {
                options.ToTable(nameof(SalesDocumentCustomerDetails))
                    .HasKey(x => x.Id)
                    .IsClustered(false);

                options.HasIndex(p => p.CustomerId)
                    .IsClustered();

                options.HasOne<Customer>()
                    .WithOne()
                    .HasForeignKey<SalesDocumentCustomerDetails>(p => p.CustomerId)
                        .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                options.HasMany<SalesDocument>()
                    .WithOne(p => p.CustomerDetails)
                    .HasForeignKey(propa => propa.CustomerDetailsId)
                        .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                options.HasOne(p => p.Customer)
                    .WithOne()
                    .HasForeignKey<SalesDocumentCustomerDetails>(p => p.CustomerId)
                        .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });
    }
}