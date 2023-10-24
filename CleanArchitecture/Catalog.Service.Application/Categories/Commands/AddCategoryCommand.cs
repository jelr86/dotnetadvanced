using System;
using Catalog.Service.App.Categories.Commands;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Commands
{
	public class AddCategoryCommand : IAddCategoryCommand
    {
		private readonly ICatalogDbContext _context;
		public AddCategoryCommand(ICatalogDbContext context)
		{
			_context = context;
		}

		public Category Execute(string name, string image, int? parentCategoryId)
		{
			var category = new Category()
			{
				Name = name,
				Image = image,
				ParentCategoryId = parentCategoryId
			};
			_context.Categories.Add(category);
			_context.SaveChangesAsync(CancellationToken.None);
			return category;
		}
	}
}

