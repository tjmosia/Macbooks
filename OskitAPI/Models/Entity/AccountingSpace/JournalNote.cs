﻿using Microsoft.EntityFrameworkCore;

using MacbooksAPI.Models.Entity.GeneralSpace;

namespace MacbooksAPI.Models.Entity.AccountingSpace
{
    public class JournalNote
    {
        public virtual string? JournalId { get; set; }
        public virtual string? NoteId { get; set; }

        public virtual Note? Note { get; set; }

        public static void BuildModel (ModelBuilder builder)
        {
            builder.Entity<JournalNote>(options =>
            {
                options.ToTable(nameof(JournalNote))
                    .HasKey(p => new { p.JournalId, p.NoteId })
                    .IsClustered(false);
            });
        }
    }
}
