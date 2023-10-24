using System;
using System.Collections.Generic;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Common.Interfaces
{
	public interface ICatalogDbContext
	{
        DbSet<Category> Categories { get; set; }
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

