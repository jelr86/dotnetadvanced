using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Commands
{
	public interface IUpdateItemCommand
	{
		Item Execute(int id, Item modified);
	}
}

