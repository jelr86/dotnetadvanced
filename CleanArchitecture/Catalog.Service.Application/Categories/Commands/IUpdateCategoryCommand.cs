using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Commands
{
	public interface IUpdateCategoryCommand
	{
		Category Execute(int categoryId, Category modified);
		
	}
}

