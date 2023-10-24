using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Queries
{
	public interface IListItemsQuery
	{
		List<Item> Query();
	}
}

