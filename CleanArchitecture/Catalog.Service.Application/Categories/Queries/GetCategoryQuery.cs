using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Queries
{
    public class GetCategoryQuery : IGetCategoryQuery
	{
        private readonly ICatalogDbContext _context;
		public GetCategoryQuery(ICatalogDbContext context)
		{
            _context = context;
		}

        public Category Query(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Id");

            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}

