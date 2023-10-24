using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Queries
{
    public class ListCategoriesQuery : IListCategoriesQuery
	{
        private readonly ICatalogDbContext _context;
		public ListCategoriesQuery(ICatalogDbContext context)
		{
            _context = context;
		}

        public List<Category> Query()
        {
            return _context.Categories.ToList();
        }
    }
}

