using System;
using Catalog.Service.App.Models;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Commands
{
	public interface IAddItemCommand
	{
		Item Execute(NewItem newItem);
	}
}

