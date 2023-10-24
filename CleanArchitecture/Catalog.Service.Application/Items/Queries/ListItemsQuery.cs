using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Queries
{
	public class ListItemsQuery : IListItemsQuery
	{
        private readonly ICatalogDbContext _context;
		public ListItemsQuery(ICatalogDbContext context)
		{
            _context = context;
		}

        public List<Item> Query()
        {
            return _context.Items.ToList();
        }
    }
}

