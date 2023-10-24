using System;
using Microsoft.EntityFrameworkCore;
using Catalog.Service.Domain.Entities;
using System.Reflection;
using Catalog.Service.App.Common.Interfaces;

namespace Catalog.Service.Infra.Database
{
	public class CatalogDbContext : DbContext, ICatalogDbContext
    {
        public CatalogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

