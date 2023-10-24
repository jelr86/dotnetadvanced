using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Queries
{
	public interface IGetCategoryQuery
	{
		Category Query(int id);
	}
}

