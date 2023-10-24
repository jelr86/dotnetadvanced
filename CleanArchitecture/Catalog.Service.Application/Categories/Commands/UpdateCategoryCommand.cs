using System;
using Catalog.Service.App.Categories.Queries;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Commands
{
	public class UpdateCategoryCommand : IUpdateCategoryCommand
	{
        private readonly ICatalogDbContext _context;

		public UpdateCategoryCommand(ICatalogDbContext context)
		{
            _context = context;
		}

        public Category Execute(int categoryId, Category modified)
        {
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            if (category == null) throw new Exception($"Error updating category:No category with id {categoryId} was found");
            
            category.Name = modified.Name;
            category.Image = modified.Image;
            category.ParentCategoryId = modified.ParentCategoryId;
            _context.SaveChangesAsync(CancellationToken.None);
            
            return category;
        }
    }
}

