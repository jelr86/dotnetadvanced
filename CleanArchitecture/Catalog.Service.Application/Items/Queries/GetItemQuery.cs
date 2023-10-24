using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Queries
{
	public class GetItemQuery : IGetItemQuery
	{
        private readonly ICatalogDbContext _context;
		public GetItemQuery(ICatalogDbContext context)
		{
            _context = context;
		}

        public Item Query(int id)
        {
            return _context.Items.Find(id);
        }
    }
}

