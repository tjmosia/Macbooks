﻿using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace MacbooksAPI.Models.Entity.SystemSpace
{
    public class ShippingMethod
    {
        public virtual string? Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? ShortName { get; set; }
        public virtual string? Description { get; set; }

        [ConcurrencyCheck]
        public virtual string? RowVersion { get; set; }

        public void UpdateConcurrencyToken ()
            => RowVersion = Guid.NewGuid().ToString("N");

        public ShippingMethod ()
            => Id = Guid.NewGuid().ToString("N");

        public static void BuildModel (ModelBuilder builder)
            => builder.Entity<ShippingMethod>(options =>
            {
                options.ToTable(nameof(ShippingMethod))
                    .HasKey(p => p.Id)
                    .IsClustered();

                options.HasIndex(p => p.Name)
                    .IsUnique();

                options.HasIndex(p => p.ShortName)
                    .IsUnique();
            });
    }
}
