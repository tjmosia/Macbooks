﻿using Microsoft.EntityFrameworkCore;

using OskitAPI.Models.Entity.GeneralSpace;

namespace OskitAPI.Models.Entity.SupplierSpace
{
    public class SupplierNote
    {
        public virtual string? SupplierId { get; set; }
        public virtual string? NoteId { get; set; }

        public virtual Note? Note { get; set; }

        public static void BuildModel (ModelBuilder builder)
            => builder.Entity<SupplierNote>(options =>
            {
                options.ToTable(nameof(SupplierNote))
                    .HasKey(p => new { p.SupplierId, p.NoteId })
                    .IsClustered();
            });
    }
}