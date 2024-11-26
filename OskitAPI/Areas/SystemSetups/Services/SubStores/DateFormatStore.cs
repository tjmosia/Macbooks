﻿using Microsoft.EntityFrameworkCore;

using MacbooksAPI.Core.EFCore;
using MacbooksAPI.Data;
using MacbooksAPI.Models.Entity.SystemSpace;

namespace MacbooksAPI.Areas.SystemSetups.Services.SubStores
{
    public class DateFormatStore : DbStoreBase
    {
        public DateFormatStore (AppDbContext? context, ILogger<DateFormatStore>? logger)
            : base(context, logger) { }

        public async Task<DateFormat> CreateAsync (DateFormat dateFormat)
        {
            var result = await context!.DateFormat.AddAsync(dateFormat);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DateFormat> UpdateAsync (DateFormat dateFormat)
        {
            var result = context!.DateFormat.Update(dateFormat);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DateFormat?> FindByIdAsync (string id)
            => await context!.DateFormat.FindAsync(id);

        public async Task DeleteAsync (params DateFormat[] dateFormats)
        {
            context!.DateFormat.RemoveRange(dateFormats);
            await context.SaveChangesAsync();
        }

        public async Task<IList<DateFormat>> FindAllAsync ()
            => await context!.DateFormat.ToListAsync();
    }
}
