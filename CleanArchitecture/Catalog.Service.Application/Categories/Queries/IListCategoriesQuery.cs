using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Queries
{
	public interface IListCategoriesQuery
	{
		List<Category> Query();
	}
}

